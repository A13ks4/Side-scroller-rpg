using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//Enemy health display, and death condition
public class EnemyHealth : MonoBehaviour {

    protected Enemy enemyStats;

    public GameObject healthBar;
    public GameObject damageNums;
    public int offsetX, offsetY;

    private Slider slider;
    private Text text;
    private GameObject ob;

	// Use this for initialization
	void Start () {
        enemyStats = new Enemy(15,0,30,5);
        ob = Instantiate(healthBar, this.transform.position, transform.rotation);
        ob.transform.position = new Vector2(transform.position.x+ offsetX, transform.position.y+offsetY);
        slider = ob.transform.GetChild(0).GetComponent<Slider>();
        text = ob.transform.GetChild(1).GetComponent<Text>();
        text.text = enemyStats.Health + " / " + enemyStats.MaxHealth;
        slider.maxValue = enemyStats.MaxHealth;
        slider.value = enemyStats.Health;
        ob.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (enemyStats.Health <= 0)
        {
            Destroy(ob);
            Destroy(this.gameObject);
            GameControl.Instance.GiveReward(enemyStats.Reward);
        }
        else {
            ob.transform.position = new Vector2(transform.position.x + offsetX, transform.position.y + offsetY);
        }
		
	}
    public void DoDamage(int dmg) {
        if(enemyStats.Health == enemyStats.MaxHealth)
            ob.SetActive(true);
        enemyStats.TakeDmg(dmg);
        slider.value = enemyStats.Health;
        text.text = enemyStats.Health + " / " + enemyStats.MaxHealth;
        slider.value = enemyStats.Health;
        //Floating damage - also needs to be in a different place
        GameObject obj = Instantiate(damageNums, new Vector3(transform.position.x, transform.position.y+2, 0), transform.rotation);
        obj.transform.GetChild(0).GetComponent<Text>().text = "-" + dmg;
    }

}
