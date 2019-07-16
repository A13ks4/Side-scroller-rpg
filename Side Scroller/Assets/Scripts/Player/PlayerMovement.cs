using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

//Movement system for player
public class PlayerMovement : MonoBehaviour {

    public GameObject gun;
    public Transform firePoint;
    public GameObject bullet;
    public float speed;
    public float inAirSpeed;
    public int jumpHeight;
    public int smallJump = 2;
    private Vector2 moveVelocity;
    private Rigidbody2D rb;
    private Animator anim;
    private Animator gunAnim;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool grounded;
    public float fallVel;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        gunAnim = gun.transform.GetComponent<Animator>();
    }
    void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        
        //moveVelocity = moveVelocity.normalized;
        //rb.position = rb.position + moveVelocity * moveVelocity.magnitude;
    }

    // Update is called once per frame
    void Update () {

        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        if (grounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        rb.velocity = new Vector2(moveVelocity.x, rb.velocity.y);


        if (grounded && Input.GetButton("S"))
        {
            moveVelocity.x *= 0.5f;
            anim.SetBool("crouching", true);
        }
        else
        {
            moveVelocity.x = speed * Input.GetAxisRaw("Horizontal");
            anim.SetBool("crouching", false);
        }
        
        if (!grounded)
        {
            anim.SetBool("jumped", true);
           

            if (rb.velocity.y < -0.3)
            {
                rb.velocity = new Vector2(moveVelocity.x, rb.velocity.y - fallVel);
            } else if (rb.velocity.y > 0 && Input.GetButtonUp("Jump")) {
                
                rb.velocity = new Vector2(moveVelocity.x, rb.velocity.y* 0.5f);
            }
        }
        else
        {
            anim.SetBool("jumped", false);
        }

        


        if (moveVelocity.x < 0){
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (moveVelocity.x > 0){
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        
       
      
        anim.SetFloat("speed", Mathf.Abs(moveVelocity.x));


        //TODO:: Put in diferent Script combat!!!
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("slash");
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Enemy")
        {
            
            other.GetComponentInParent<EnemyHealth>().DoDamage(5);
            //Deal Damage!!!
        }
    }
}
