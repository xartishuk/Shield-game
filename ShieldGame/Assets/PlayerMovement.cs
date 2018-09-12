using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    private float horizontal;
    private Vector2 velocity;
    public Rigidbody2D rb;
    public float acceleration = 1f;
    public float deceleration = 1f;
    public float maxSpeed = 1f;
    public float jumpMultiplier = 1f;
    private Vector2 jumpVector;

	// Use this for initialization
	void Start () {
        horizontal = 0f;
        velocity = new Vector2();
        jumpVector = new Vector2(0, jumpMultiplier);
	}
	
	// Update is called once per frame
    private void Update()
    {

        HorizontalMovement();
        Jump();
        
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            velocity.x = rb.velocity.x;
            velocity.y = 0;
            rb.velocity = velocity;
            rb.AddForce(jumpVector, ForceMode2D.Impulse);
        }
    }

    void HorizontalMovement()
    {
        if ((horizontal = Input.GetAxis("Horizontal")) != 0)
        {
            velocity.x = Mathf.Sign(horizontal) * maxSpeed;
        }
        else
        {
            velocity.x = 0;
        }

        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }
}
