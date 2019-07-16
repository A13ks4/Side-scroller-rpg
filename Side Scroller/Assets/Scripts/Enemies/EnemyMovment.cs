using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//State does the movement
public class EnemyMovment : MonoBehaviour {

    public float speed;
    public float time;
    public float waitTime;
    public float shootTime;
    public bool detected;
    public GameObject bullet;
    public Transform firePos;
    public float savedTime;
    public float savedWaitTime;
    public float savedSpeed;
    public LayerMask whatisPlayer;
    public bool shoot = false;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public Rigidbody2D rb;
    public bool grounded;

    public Animator anim;
    public State state;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       
        savedTime = time;
        savedWaitTime = waitTime;
        savedSpeed = speed;
	}


	// Update is called once per frame
	void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        state.UpdateState(this);
        
        

       
    }
    public void ChangeState(State st) {
        if(state != st)
            state = st;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            GameControl.Instance.DamagePlayer(5);
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        
            
    }

    public void Fire() {
        Instantiate(bullet, firePos.transform.position, transform.rotation);
    }
}
