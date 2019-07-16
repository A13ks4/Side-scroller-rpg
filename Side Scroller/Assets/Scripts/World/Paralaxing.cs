using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Paralexing for camera
public class Paralaxing : MonoBehaviour {

    public Transform[] backgrounds;
    private float[] parallaxScales;
    public float smoothing;

    private Transform cam;
    private Vector3 prevcamPos;


    // Use this for initialization
    void Start()
    {
        cam = Camera.main.transform;

        prevcamPos = cam.position;

        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (prevcamPos.x - cam.position.x) * parallaxScales[i];
            float backTargPosX = backgrounds[i].position.x + parallax;
            float parallaxY = (prevcamPos.y - cam.position.y) * parallaxScales[i];
            float backTargPosY = backgrounds[i].position.y + parallaxY;
            Vector3 backGroundTarg = new Vector3(backTargPosX, backTargPosY, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backGroundTarg, smoothing * Time.deltaTime);
        }
        prevcamPos = cam.position;
        
    }
}
