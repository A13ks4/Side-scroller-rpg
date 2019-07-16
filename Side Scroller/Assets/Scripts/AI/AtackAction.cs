using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Concrete action which implements action and performs a specific action
[CreateAssetMenu (menuName = "PlugableAi/Actions/AttackAction")]
public class AtackAction : Action
{
    

    public override void Act(EnemyMovment em){
        Attack(em);
    }
    //Logic for attack
    private void Attack(EnemyMovment em) {
        if (em.detected)
        {
            em.anim.SetFloat("speed", 0);
        }
        if (em.shoot)
        {
            em.shootTime -= Time.deltaTime;
            em.rb.velocity = new Vector3(0, em.rb.velocity.y, 0);

            if (em.shootTime <= 0)
            {
                em.shootTime = 3;
                em.anim.SetTrigger("fire");
            }
        }
        else {
            em.shootTime -= Time.deltaTime;
            em.rb.velocity = new Vector3(0, em.rb.velocity.y, 0);
            
            if (em.shootTime <= 0)
            {
                em.shootTime = 2;
                em.anim.SetTrigger("attack");
                
            }
        }
    }

}

