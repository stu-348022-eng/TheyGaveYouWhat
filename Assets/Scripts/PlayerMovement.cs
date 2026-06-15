using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private bool grounded;
    public bool FacingLeft;
    

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


        if (Input.GetKey(KeyCode.Space) && grounded)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }




}
