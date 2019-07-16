using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player stats that inherits Stats
public class Player : Stats{

    private int exp;
    private int lvl;
    private int skillPoints;
    private List<int> modifiers = new List<int>();
    public delegate void UpdateStatsCallback();
    public UpdateStatsCallback updateStats;

    

    public int Exp { get { return exp; } set { if (value >= 100) { exp = 0; ++Lvl; } else { exp = value; } } }
    public int Lvl { get { return lvl; } set { lvl = value; ++skillPoints; } }
    public int SkillPoints { get { return skillPoints; } set { skillPoints = value; } }

    public Player():base(25,0,5) {   exp = 0; lvl = 1; }
    public Player(int h, int s = 0, int d = 5):base(h,s,d) { exp = 0; lvl = 1; }

    public void UpdateEfects() {
        if (effects != null) {
            for (int i = 0; i<effects.Count;i++) {
                effects[i].UpdateEffect.Invoke(this,Time.deltaTime);
            }
        }
    }
    public override void UpdateStats(){
        updateStats.Invoke();
    }

    public void AddHealth(int amt){
        addHealth(amt);
        updateStats.Invoke();
    }

    public void AddExp(int amt){
        Exp += amt;
        updateStats.Invoke();
    }
    public void UpgradeHealth(int amt) { MaxHealth += amt; Health = MaxHealth; --SkillPoints; }
    public void UpgradeShild(int amt) { MaxShild += amt; Shild = MaxShild; --SkillPoints; }
    public void AddModifier(int m) { if (m != 0) modifiers.Add(m); }
    public void RemoveModifier(int m) { if (m != 0) modifiers.Remove(m); }
}
