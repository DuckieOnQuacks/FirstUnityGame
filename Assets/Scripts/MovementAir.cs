using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovementAir : MonoBehaviour
{
    //public Animator animator;
    private bool facingRight = true; //Depends on if your animation is by default facing right or left
    public float speed = 5;
    public int force = 20;
    public Transform groundCheck; //Marker to see where players feet are
    public float groundCheckRadius; //Draw circle around feet
    public LayerMask groundLayer; //Create a place to insert the ground layer

    public Rigidbody2D Player2DAir;
    public GameObject player;
    public GameObject playerAir;

    private bool isTouchingGround;

    void Awake()
    {
        Player2DAir = GetComponent<Rigidbody2D> ();
    }

    //////////////////////
    private void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        //animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal * speed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.E) || isTouchingGround == true)
        {   
            isTouchingGround = false;
            Instantiate(player, playerAir.transform.position, Quaternion.identity);
            playerAir.GetComponent<playerCollision>().health  = player.GetComponent<playerCollision>().health;
            Destroy(gameObject);  
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            Player2DAir.AddForce(Vector3.up * force);
        }
 
        if (Input.GetKey(KeyCode.S))
        {
            Player2DAir.AddForce(Vector3.down * force);
        }
    }
 

    ///////////////////////
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if(h > 0 && !facingRight)
            Flip();
        else if(h < 0 && facingRight)
            Flip();
    }
    /////////////
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
    }
}

