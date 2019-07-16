using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Concrete action which implements action and performs a specific action
[CreateAssetMenu(menuName = "PlugableAi/Actions/PatrolAction")]
public class PatrolAction : Action{
    public override void Act(EnemyMovment em){
        Patrol(em);
    }
    //Logic for patrol
    private void Patrol(EnemyMovment em) {
        em.time -= Time.deltaTime;
        if (em.time <= 0)
        {
            em.waitTime -= Time.deltaTime;

            if (em.waitTime <= 0)
            {
                em.time = em.savedTime;
                em.speed = em.savedSpeed;
                em.speed = -em.speed;
                em.waitTime = em.savedWaitTime;
                em.savedSpeed = em.speed;
            }
            else
            {
                em.speed = 0;
            }

        }
        if (!em.grounded && em.rb.velocity.y < -0.1)
        {
            //speed = 0;
        }
        else if (!em.grounded)
        {
            em.speed = -em.speed;
        }

        if (em.speed < 0)
        {
            em.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            em.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        em.rb.velocity = new Vector3(em.speed, em.rb.velocity.y, 0);
        em.anim.SetFloat("speed", Mathf.Abs(em.speed));
    }
}
