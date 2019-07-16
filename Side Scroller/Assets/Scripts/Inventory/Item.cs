using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Data for items
public class Item : IEquatable<Item> {

    public enum ItemTypes { CURENCY, POTION, WEPON, AUGMENT }
    protected ItemTypes itemType;
    protected string name;
    protected int amount;
    protected int effectAmount;

    protected int price;


    public EffectData effects = new EffectData("item");

    public string Name { get { return name; } set { name = value; }  }
    public int Amount { get { return amount; } set { amount = value; } }
    public int EffectAmount { get { return effectAmount; } set { effectAmount = value; } }
    public int Price { get { return price; } set { price = value; } }
    public ItemTypes ItemType { get { return itemType; } set { itemType = value; } }

    public Item(string name, int amt,ItemTypes type ,int efamt = 0,  int price = 0) { ItemType = type; this.name = name; this.amount = amt; this.effectAmount = efamt; this.price = price;  }
    public Item(Item it) { effects = it.effects; itemType = it.ItemType; name = it.Name; amount = it.Amount; effectAmount = it.EffectAmount; price = it.Price; }

    public virtual void onUse(Stats p) {
        //DoSomething
        if (effects.OnConsumeEffect != null)
            effects.OnConsumeEffect.Invoke(p,this);
    }

    public bool Equals(Item other) {
        if (other == null) return false;
        return (this.Name.Equals(other.Name));
    }
    
}
