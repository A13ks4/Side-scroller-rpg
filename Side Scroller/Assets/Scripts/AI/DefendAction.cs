using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Concrete action which implements action and performs a specific action
[CreateAssetMenu(menuName = "PlugableAi/Actions/DefendAction")]
public class DefendAction : Action{
   

    public override void Act(EnemyMovment em){
        Defend(em);
    }
    //Logic for defense
    public void Defend(EnemyMovment em) {
        if (em.detected)
        {
            em.anim.SetTrigger("detected");
        }
        
    }
}
