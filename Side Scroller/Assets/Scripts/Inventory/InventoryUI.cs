using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//UI for inventory
public class InventoryUI : MonoBehaviour {

    public Transform invPanel; //Inventory Panel
    public GameObject slot; //SlotPrefab
    public Slot[] slots;

    public GameObject popUp;//Item popup on the side when pick up
    public Transform popUpParent;

    //Sprites
    private Object[] sprites;
    private Dictionary<string, Sprite> AllSprites;
    // Use this for initialization
    void Start()
    {
        sprites = Resources.LoadAll("Items", typeof(Sprite));
        AllSprites = new Dictionary<string, Sprite>();
        foreach (Sprite sp in sprites) {
            AllSprites.Add(sp.name, sp);
        }
        PlayerInventory.Instance().updateUI += UpdateInventory;
        PlayerInventory.Instance().popUpUpdate += popUpOnPickUp;
        for (int i = 0; i < 20; ++i){
            GameObject ob = Instantiate(slot, transform.position, transform.rotation);
            ob.transform.SetParent(invPanel);

        }
        slots = invPanel.GetComponentsInChildren<Slot>();

    }
    void Update()
    {
        if (Input.GetButtonDown("inventory"))
        {
            invPanel.parent.gameObject.SetActive(!invPanel.parent.gameObject.activeSelf);
        }
    }

    void UseItem() {

    }

    void UpdateInventory(Item it){
        
        for (int i = 0; i < slots.Length; ++i) {
            if (i < PlayerInventory.Instance().inventory.Count)
                slots[i].AddItem(PlayerInventory.Instance().inventory[i], AllSprites[PlayerInventory.Instance().inventory[i].Name]);
            else
                slots[i].RemoveItem();
        }
        //popUpOnPickUp(it);
    }

    void popUpOnPickUp(Item it) {
        GameObject ob = Instantiate(popUp,transform.position,transform.rotation);
        ob.transform.SetParent(popUpParent);
        ob.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Image>().sprite = AllSprites[it.Name];
        ob.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = it.Name+" x "+it.Amount;
    }
}
