using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    protected Rigidbody2D rb;

	protected float move_speed = 5f;
    protected float jump_speed = 200f;
    protected float jump_ramp = 0;
    protected float jump_cap = 10;
    protected float jump_counter = 0;

    protected bool jump = false;
    protected bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

    void HandleMovement()
    {
        Vector3 movement = new Vector3(0, 0, 0);

        if(jump)
        {
            jump_counter++;
            Debug.Log(jump_counter);
            if (jump_counter >= jump_cap) { jump = false; jump_counter = 0; }
        }

        if(!isGrounded && Input.GetKey(KeyCode.W))
        {
            if (jump && jump_counter % 3 == 0)
            {
                rb.AddForce(new Vector2(0, jump_speed));
            }  
        }

        if (isGrounded && Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector2(0, jump_speed));
            jump = true;
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement.x = move_speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -move_speed * Time.deltaTime;
        }

        this.transform.position = this.transform.position + movement;
    }
}
