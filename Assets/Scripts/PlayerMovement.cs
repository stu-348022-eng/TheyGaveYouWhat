using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private bool grounded;
    public bool FacingLeft;
    public bool CanJump;
    
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if(horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
            FacingLeft = false;
        }

        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            FacingLeft = true;
        }


        if (Input.GetKey(KeyCode.Space) && grounded && CanJump)
        {
            if(grounded == true)
            {
                Jump();
            }
            
        }



    }

    

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;
    }

    private void Climbing()
    {
        body.velocity = new Vector2(body.velocity.x, 4f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            grounded = true;
            CanJump = true;
        }

        if (collision.gameObject.tag == "death")
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Climable")
        {

            CanJump = false;
            if (Input.GetKey(KeyCode.Space) )
            {
                Climbing();
                
            }
        }
    }




}
