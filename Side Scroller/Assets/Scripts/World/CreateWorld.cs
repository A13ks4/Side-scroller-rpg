using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Object pool
public class CreateWorld : MonoBehaviour {

    public GameObject[] prefab = new GameObject[1];
    public int[] probability = new int[10]; 
    public int pooledAmount = 20;

    public Transform back;
    public Transform front;
    public int MaxY, MinY, size;

    private List<GameObject> activeObs;
    private List<GameObject> pooledObjs;

    private Vector2 pos;

    void OnEnable()
    {
        pooledObjs = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            int rnd = Random.Range(0, 100);
            for (int j = 0; j < probability.Length; ++j){
                if (rnd < probability[j])
                {
                    GameObject ob = (GameObject)Instantiate(prefab[j], new Vector3(0, 0, 0), prefab[j].transform.rotation);
                    ob.transform.SetParent(this.gameObject.transform);
                    ob.SetActive(false);
                    pooledObjs.Add(ob);
                }
                else {
                    GameObject ob = (GameObject)Instantiate(prefab[0], new Vector3(0, 0, 0), prefab[0].transform.rotation);
                    ob.transform.SetParent(this.gameObject.transform);
                    ob.SetActive(false);
                    pooledObjs.Add(ob);
                }
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        activeObs = new List<GameObject>();

      

        GameObject ob = PutObjInPlace(0);
        ob.SetActive(true);
        activeObs.Add(ob);
    }

    // Update is called once per frame
    void Update()
    {
        if (activeObs.Count != 0)
        {
            if (back.position.x > activeObs[0].transform.position.x)
            {
                RemoveObj(activeObs[0]);
            }
            

            if (front.position.x > activeObs[activeObs.Count - 1].transform.position.x)
            {
                AddObj();
            }
        }

    }

    void RemoveObj(GameObject ob)
    {
        ob.SetActive(false);
        activeObs.RemoveAt(0);
    }

    void AddObj(){
        int rnd = Random.Range(0, prefab.Length);
        GameObject ob = PutObjInPlace(rnd);
        pos = new Vector2(activeObs[activeObs.Count - 1].transform.position.x + size, Random.Range(MinY, MaxY));
        ob.transform.position = pos;
        ob.SetActive(true);
        ob.transform.SetParent(this.transform);
        activeObs.Add(ob);


    }

   

    public GameObject PutObjInPlace(int num)
    {

        for (int i = 0; i < pooledObjs.Count - 1; i++)
        {
            if (pooledObjs[i].activeInHierarchy == false)
            {
                return pooledObjs[i];
            }
        }
        GameObject obj = (GameObject)Instantiate(prefab[num], new Vector3(0, 0, 0), prefab[num].transform.rotation);
        obj.SetActive(false);
        obj.transform.SetParent(this.gameObject.transform);
        return obj;
    }
}
