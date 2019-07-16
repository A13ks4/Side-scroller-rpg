using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Does damage on entering the area
public class SpikeDamage : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player") {
            GameControl.Instance.DamagePlayer(2);

            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(15, 15), ForceMode2D.Impulse);
        }

    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
             
        }
    }
}
