using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMove : MonoBehaviour
{
    public Rigidbody2D rb;
    bool IsGrounded;

    private float Move;
    public float speed;
    public float jump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
 

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(Move * speed, rb.velocity.y);

        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown("w")) && IsGrounded)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump * 10));
        }
    }
    private void OnCollisionEnter2D(Collision2D other) //checks if player is grounded
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) //checks if player is grounded
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsGrounded= false;

        }
    }
}
