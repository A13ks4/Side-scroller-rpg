using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base player stats
public class Stats {

    protected int health;
    protected int maxHealth;
    protected int shild;
    protected int maxShild;
    protected int damage;

    public List<EffectData> effects = new List<EffectData>();

    public int Health { get { return health; } set { health = value; } }
    public int Shild { get { return shild; } set { shild = value; } }
    public int MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    public int MaxShild { get { return maxShild; } set { maxShild = value; } }
    public int Damage { get { return damage; } set { damage = value; } }

    protected Stats(int h, int s, int d) { health = h; shild = s; maxHealth = health; maxShild = 0; damage = d; }

    public void addHealth(int v) { if (health + v < maxHealth) health = health + v; else health = maxHealth; }
    public void TakeDmg(int d) { health -= d; }

    public void AddEffect(EffectData e) {
        for (int i = 0; i < effects.Count; i++) {
            if (effects[i].Equals(e)) {
                Debug.Log("Already in");
                return;
            }
        }
        if (e != null) effects.Add(e);
    }
    public void RemoveEffects(EffectData e) { if (e != null) effects.Remove(e); }

    public virtual void UpdateStats() { }
}
