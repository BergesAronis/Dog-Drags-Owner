using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour {

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 100f;

    private bool jumpable = false;
    private Rigidbody2D rigidbody;
    private Animator anim;
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
		
	}

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("Horizontal", Mathf.Abs(horizontal));

        if (horizontal * rigidbody.velocity.x < maxSpeed)
        {
            rigidbody.AddForce(Vector2.right * horizontal * moveForce);
        }

        if (Mathf.Abs(rigidbody.velocity.x) > maxSpeed)
        {
            rigidbody.velocity = new Vector2(Mathf.Sign(rigidbody.velocity.x) * maxSpeed, rigidbody.velocity.y);
        }

        if (horizontal == 0)
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }

        if (horizontal > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontal < 0 && facingRight)
        {
            Flip();
        }

        if (jump)
        {
            rigidbody.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }

        anim.SetFloat("Vertical", rigidbody.velocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 thescale = transform.localScale;
        thescale.x *= -1;
        transform.localScale = thescale;
    }
}
