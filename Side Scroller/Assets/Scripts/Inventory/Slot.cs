using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Individual slots in the inventory
public class Slot : MonoBehaviour {

    public Item item;

    public Image img;
    public Text text;


    public void AddItem(Item it, Sprite sp) {
        item = it;

        img.gameObject.SetActive(true);
        img.sprite =  sp;
        text.text = it.Amount.ToString();
    }
    public void RemoveItem() {
        item = null;
        img.gameObject.SetActive(false);
        text.text = "";
    }

    public void UseItem() {//Check first what type it is before removing it and check if there is more than one!!!
        if (item != null && item.ItemType != Item.ItemTypes.CURENCY)
        {
            item.onUse(GameControl.Instance.GetPlayerStats().GetPlayer());
            if (item.Amount == 1)
            {
                PlayerInventory.Instance().RemoveFromInventory(item.Name);
            }
            else
            {
                item.Amount--;
                PlayerInventory.Instance().updateUI(item);
            }
        }
    }
}
