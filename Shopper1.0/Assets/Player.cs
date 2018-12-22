using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    protected Rigidbody2D body;
    protected BoxCollider2D collider;

    protected float speed = 5;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        HandleMovement();
    }

    protected void HandleMovement()
    {
        Vector3 movement = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            movement.y = speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement.y = -speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement.x = speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -speed * Time.deltaTime;
        }

        this.transform.position = this.transform.position + movement;
    }
}
