using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveForce = 365f;
    public float maxSpeed = 5f;


    Rigidbody2D playerRigidbody;

    public float moveSpeed;
	// Use this for initialization
	void Start ()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal * playerRigidbody.velocity.x < maxSpeed)
        {
            playerRigidbody.AddForce(Vector2.right * horizontal * moveForce);
        }

        if (Mathf.Abs(playerRigidbody.velocity.x) > maxSpeed)
        {
            playerRigidbody.velocity = new Vector2(Mathf.Sign(playerRigidbody.velocity.x) * maxSpeed, playerRigidbody.velocity.y);
        }

        if (horizontal == 0)
        {
            playerRigidbody.velocity = new Vector2(0, playerRigidbody.velocity.y);
        }

        if (vertical * playerRigidbody.velocity.y < maxSpeed)
        {
            playerRigidbody.AddForce(Vector2.up * vertical * moveForce);
        }

        if (Mathf.Abs(playerRigidbody.velocity.y) > maxSpeed)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, Mathf.Sign(playerRigidbody.velocity.y) * maxSpeed);
        }

        if (vertical == 0)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0);
        }

    }
}
