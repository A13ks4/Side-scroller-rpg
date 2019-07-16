using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base enemy stats
public class Enemy : Stats {

    protected int reward;//TODO::Make a class

    public int Reward { get { return reward; } set { reward = value; } }

    public Enemy(int h, int s,int r, int d = 10) : base(h,s,d) { reward = r; }
}
