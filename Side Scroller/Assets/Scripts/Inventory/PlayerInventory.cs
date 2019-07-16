using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inventory that the player has, can have only one
public class PlayerInventory : MonoBehaviour {

    public delegate void OnUpdateUI(Item it);
    public OnUpdateUI updateUI;
    public OnUpdateUI popUpUpdate;

    #region Singlton
    private static PlayerInventory instance;
    public static PlayerInventory Instance() {    
        return instance;
    }
    #endregion

    public List<Item> inventory;
    private Dictionary<string, Item> prototypes;
    

    void Awake() {
        if (instance == null){
            instance = this;
        }

        inventory = new List<Item>();
        prototypes = new Dictionary<string, Item>();
   

        prototypes.Add("crystal", new Item("crystal", 1, Item.ItemTypes.CURENCY,1,25));
        Item it = new Item("healthPotion", 1,Item.ItemTypes.POTION,10,20);
        it.effects.OnConsumeEffect += ItemEffects.healOverTime;
        prototypes.Add("healthPotion",it);
        Item itt = new Item("speedPotion", 1, Item.ItemTypes.POTION, 10, 20);
        itt.effects.OnConsumeEffect += ItemEffects.speedOverTime;
        prototypes.Add("speedPotion", itt);


    }



    public bool AddToInventory(string name) {
        //Check if the item is stackable and if it isn allready in inventory
        if (!prototypes.ContainsKey(name))
            return false;
        foreach (Item it in inventory) {
            if (it.Name == name) {
                it.Amount++;
                if (updateUI != null && popUpUpdate != null) {
                    updateUI.Invoke(prototypes[name]);
                    popUpUpdate.Invoke(prototypes[name]);
                }
                return true;
            }
        }
        Item proto = new Item(prototypes[name]);
        inventory.Add(proto);

        if (updateUI != null && popUpUpdate != null) { 
            updateUI.Invoke(proto);
            popUpUpdate.Invoke(proto);
        }
        return true;
    }
    public void RemoveFromInventory(string name) {
        inventory.Remove(prototypes[name]);
        if (updateUI != null)
            updateUI.Invoke(prototypes[name]);
    }
}
