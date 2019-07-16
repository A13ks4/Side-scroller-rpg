using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player's bullet movement
public class PlayerBullet : MonoBehaviour {

    private PlayerMovement player;
    private Rigidbody2D rb;
    public int speed;
    public float timer;
    public int dmg;
    public GameObject particle;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        
        if (player.transform.localScale.x < 0) {
            transform.rotation =  Quaternion.Euler(0,0,180);
            speed = -speed;
        }
        Instantiate(particle, this.transform.position, transform.rotation);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.AddForce(new Vector2(speed, 0), ForceMode2D.Impulse);
        if (timer <= 0) {
            Destroy(this.gameObject);
        }
        timer -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground") {
            Destroy(this.gameObject);
        }else if(other.tag == "Enemy") {
            Destroy(this.gameObject);
            Instantiate(particle, this.transform.position, transform.rotation);
            other.GetComponentInParent<EnemyHealth>().DoDamage(dmg);
            //Deal Damage!!!
        }
    }
}
