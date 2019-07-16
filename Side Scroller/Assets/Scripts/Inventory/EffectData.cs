using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Effect data for items
public class EffectData : IEquatable<EffectData>{
    public string name;
    public EffectData(string n) { name = n; }

    public delegate void StateEventHandler(Stats ch, Item it);
    public delegate void UpdateEventHandler(Stats ch, float deltaTime);

    public StateEventHandler StartEffect;
    public StateEventHandler EndEffect;
    public StateEventHandler OnConsumeEffect;
    public UpdateEventHandler UpdateEffect;

    public bool Equals(EffectData other) {
        if (other == null) return false;
        return (name.Equals(other.name));
    }

}
