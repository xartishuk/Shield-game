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

	// Use this for initialization
	void Start () {
        horizontal = 0f;
        velocity = new Vector2();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        HorizontalSnappy();

        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
	}


    void HorizontalSnappy()
    {
        if ((horizontal = Input.GetAxis("Horizontal")) != 0)
        {
            velocity.x = Mathf.Sign(horizontal) * maxSpeed;
        }
        else
        {
            velocity.x = 0;
        }
    }

    void HorizontalSlippery()
    {
        if ((horizontal = Input.GetAxis("Horizontal")) != 0)
        {
            velocity.x += Mathf.Sign(horizontal) * acceleration * Time.fixedDeltaTime;
            velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
        }
        else
        {
            if (velocity.x != 0f && (Mathf.Abs(velocity.x) > Mathf.Abs(acceleration * Time.fixedDeltaTime)))
            {
                velocity.x -= Mathf.Sign(velocity.x) * acceleration * Time.fixedDeltaTime;
            }
            else
            {
                velocity.x = 0;
            }
        }
    }
}
