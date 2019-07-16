using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//All the diferent effects that the items can have
public class ItemEffects {
    

    public static void InstaHeal(Stats p, Item it) {
        p.addHealth(it.EffectAmount);
    }

    public static void healOverTime(Stats c, Item it) {
        EffectData ef = new EffectData("heal");


        float duration = 9.9f;

        ef.UpdateEffect += (character, deltaTime) => {

            int numTicks = Mathf.FloorToInt(duration);
            duration -= deltaTime;
            
            if (Mathf.FloorToInt(duration) < numTicks) {
                c.addHealth(it.EffectAmount);
                c.UpdateStats();
            }

            if (duration <= 0) {
                c.RemoveEffects(ef);
            }

        };
       

        c.AddEffect(ef);
    }
    public static void speedOverTime(Stats c, Item it)
    {
        EffectData ef = new EffectData("speed");


        float duration = 9.9f;

        ef.UpdateEffect += (character, deltaTime) => {

            int numTicks = Mathf.FloorToInt(duration);
            duration -= deltaTime;

            if (Mathf.FloorToInt(duration) < numTicks)
            {
                Debug.Log("SpeedTick");
                //c.addHealth(it.EffectAmount);
                c.UpdateStats();
            }

            if (duration <= 0)
            {
                c.RemoveEffects(ef);
            }

        };


        c.AddEffect(ef);
    }

}
