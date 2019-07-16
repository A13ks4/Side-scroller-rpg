using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//Displays UI
public class GameControl : MonoBehaviour {

    public int num;
    public GameObject panel;
    public Text healthUpgrade;
    public Text ShildUpgrade;
    public Text skillPoints;

    public static GameControl Instance { get; private set; }

    public Text healthText;
    public Image playerHealth;
   // public Text shildText;
    //public Slider playerShild;

    public Image exp;
    public Text lvlText;

    private PlayerInventory pInventory;
    private PlayerStats p;
    private Player player;

    public PlayerStats GetPlayerStats() { return p; }
    // Use this for initialization
    void Awake() {
        if (Instance == null) { Instance = this; }
        p = FindObjectOfType<PlayerStats>();
    }

	void Start () {
        pInventory = FindObjectOfType<PlayerInventory>();
        
        
        player = p.GetPlayer();
        player.updateStats += UpdateStats;

        healthText.text = ""+player.Health + "/" + player.MaxHealth;
       // playerHealth.maxValue = player.MaxHealth;
        playerHealth.fillAmount = player.MaxHealth;

        //  shildText.text = "" + player.Shild + "/" + player.MaxShild;
        // playerShild.maxValue = player.MaxShild;
        //  playerShild.value = player.Shild;

        lvlText.text = "" + player.Lvl;
        exp.fillAmount = player.Exp / 100;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("C")) {
            panel.SetActive(!panel.activeSelf);
        }
    }

    void UpdateStats() {
        healthText.text = "" + player.Health + "/" + player.MaxHealth;
        playerHealth.fillAmount = (float)player.Health / (float)player.MaxHealth;
       // playerHealth.maxValue = player.MaxHealth;
       // playerHealth.value = player.Health;

       // shildText.text = "" + player.Shild + "/" + player.MaxShild;
       // playerShild.maxValue = player.MaxShild;
       // playerShild.value = player.Shild;

        lvlText.text = "" + player.Lvl;
        exp.fillAmount = player.Exp / 100f;
        skillPoints.text = "SkillPoints: " + player.SkillPoints.ToString();
        
    }

    public void DamagePlayer(int dmg) {
        player.TakeDmg(dmg);
        healthText.text = "" + player.Health + "/" + player.MaxHealth;
        playerHealth.fillAmount =(float) player.Health / (float)player.MaxHealth;

    }

    public void GiveReward(int amt) {
        player.AddExp(amt);

        
        //Check if there is space 
        pInventory.AddToInventory("crystal");
       // if (Random.Range(0, 5) % 4 == 0)
            pInventory.AddToInventory("healthPotion");
        pInventory.AddToInventory("speedPotion");
    }

    public void UpgradeHealth() {
        if (player.SkillPoints > 0)
        {
            player.UpgradeHealth(10);
            UpdateStats();
        }
        else
            Debug.Log("NoSkillPoints");

    }

    public void UpgradeShild() {
        if (player.SkillPoints > 0)
        {
            player.UpgradeShild(10);
            UpdateStats();
        }
        else
            Debug.Log("NoSkillPoints");
    }

    public void OpenMenu() {
        if (panel.activeSelf){
            panel.SetActive(false);
        }
        else {
            panel.SetActive(true);
        }
    }
}
