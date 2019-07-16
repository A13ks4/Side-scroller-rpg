using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemy bullet movement
public class EnemyBullet : MonoBehaviour {

    private PlayerStats player;
    public float speed;
    public float timer;
    public GameObject particle;

    // Use this for initialization
    void Start()
    {
        player = GameControl.Instance.GetPlayerStats();

        if (player.transform.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            speed = -speed;
        }
        else {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        Instantiate(particle, this.transform.position, transform.rotation);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate( new Vector2(speed, 0), Space.World);
        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
        timer -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        else if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            Instantiate(particle,this.transform.position, transform.rotation);
            GameControl.Instance.DamagePlayer(5);
            other.GetComponent<Rigidbody2D>().AddForce(transform.up * 15, ForceMode2D.Impulse);
        }
    }
}
