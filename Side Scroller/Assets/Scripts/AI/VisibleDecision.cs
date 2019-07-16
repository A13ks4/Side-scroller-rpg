using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Concrete decision which implements decision and performs a specific check
[CreateAssetMenu (menuName = "PlugableAi/VisibleDecision")]
public class VisibleDecision : Decision
{
    private float timer = 1;
    private Vector2 dir;

    public override bool Decide(EnemyMovment em)
    {
        return Visible(em);
    }
    //Checks if the player is in sight
    private bool Visible(EnemyMovment em) {

        
        if (em.speed < 0){
           dir =  em.transform.right;
        }
        else
        {
            dir = -em.transform.right;
        }
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(em.transform.position.x, em.transform.position.y - 0.5f), -dir, 12, em.whatisPlayer);

        //Debug.DrawLine(new Vector2(transform.position.x+5, transform.position.y-0.5f), transform.position + (-transform.right *10), Color.red);
        if (hit.collider != null){
            if (hit.distance > 4f){
                em.shoot = true;
                em.detected = true;
            }
            else if (hit.distance < 4f) {
                if (hit.collider.transform.position.x < em.transform.position.x)
                {
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        em.transform.localScale = new Vector3(1f, 1f, 1f);
                        timer = 1;
                    }
                }
                else{
                    em.transform.localScale = new Vector3(-1f, 1f, 1f);
                }
                em.detected = true;
                em.shoot = false;
            }
            //Debug.Log("Hit!!" + hit.collider.name + ": " + hit.collider.transform.position.x);
        }
        else
        {
            em.detected = false;
        }

        return em.detected;
    }
}
