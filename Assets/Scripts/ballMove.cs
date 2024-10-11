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
    public int frameTracker;
    public bool cayote;
    public  GameObject idle;
    public GameObject rightMove;
    public GameObject leftMove;
    public GameObject rightJump;
    public GameObject leftJump;
    public GameObject spawnAnimation;
    public int spawnTimer;
    public bool playerSpawned;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        frameTracker = 0;
        spawnTimer = 0;
        playerSpawned = false;
    }
 

    // Update is called once per frame
    void Update()
    {
        if (cayote)
        {
            frameTracker++;
            if (frameTracker >= 10) //gives 10 frames of cayote time to jump after leaving the ground
            {
                frameTracker = 0;
                cayote = false;
                IsGrounded = false;
            }
        }
        if (playerSpawned == false)
        {
            spawnTimer++;
            idle.GetComponent<SpriteRenderer>().enabled = false;
            spawnAnimation.GetComponent<SpriteRenderer>().enabled = true;
            if (spawnTimer >= 1850)
            {
                idle.GetComponent<SpriteRenderer>().enabled = true;
                playerSpawned = true;

            }
            if (spawnTimer >= 1900)
            {
                spawnAnimation.GetComponent<SpriteRenderer>().enabled = false;
                idle.GetComponent<SpriteRenderer>().enabled = true;
                playerSpawned = true;
                spawnTimer = 0;
            }


        }
        if (playerSpawned == true)
        {
            Move = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(Move * speed, rb.velocity.y);
            if (Move == 1)
            {
                if (IsGrounded)
                {
                    idle.GetComponent<SpriteRenderer>().enabled = false;
                    rightMove.GetComponent<SpriteRenderer>().enabled = true;
                    leftMove.GetComponent<SpriteRenderer>().enabled = false;
                    rightJump.GetComponent<SpriteRenderer>().enabled = false;
                    leftJump.GetComponent<SpriteRenderer>().enabled = false;
                    if (idle.GetComponent<SpriteRenderer>().flipX == true)
                    {
                        idle.GetComponent<SpriteRenderer>().flipX = false;
                    }
                    if (rightJump.GetComponent<SpriteRenderer>().flipX == true)
                    {
                        rightJump.GetComponent<SpriteRenderer>().flipX = false;
                    }

                }
                else
                {
                    idle.GetComponent<SpriteRenderer>().enabled = false;
                    rightMove.GetComponent<SpriteRenderer>().enabled = false;
                    leftMove.GetComponent<SpriteRenderer>().enabled = false;
                    rightJump.GetComponent<SpriteRenderer>().enabled = true;
                    leftJump.GetComponent<SpriteRenderer>().enabled = false;
                    if (idle.GetComponent<SpriteRenderer>().flipX == true)
                    {
                        idle.GetComponent<SpriteRenderer>().flipX = false;
                    }
                    if (rightJump.GetComponent<SpriteRenderer>().flipX == true)
                    {
                        rightJump.GetComponent<SpriteRenderer>().flipX = false;
                    }
                }
            }
            if (Move == 0)
            {
                if (IsGrounded)
                {
                    idle.GetComponent<SpriteRenderer>().enabled = true;
                    rightMove.GetComponent<SpriteRenderer>().enabled = false;
                    leftMove.GetComponent<SpriteRenderer>().enabled = false;
                    rightJump.GetComponent<SpriteRenderer>().enabled = false;
                    leftJump.GetComponent<SpriteRenderer>().enabled = false;
                }
                else
                {
                    idle.GetComponent<SpriteRenderer>().enabled = false;
                    rightMove.GetComponent<SpriteRenderer>().enabled = false;
                    leftMove.GetComponent<SpriteRenderer>().enabled = false;
                    rightJump.GetComponent<SpriteRenderer>().enabled = true;
                    leftJump.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            if (Move == -1)
            {
                if (IsGrounded)
                {
                    idle.GetComponent<SpriteRenderer>().enabled = false;
                    rightMove.GetComponent<SpriteRenderer>().enabled = false;
                    leftMove.GetComponent<SpriteRenderer>().enabled = true;
                    rightJump.GetComponent<SpriteRenderer>().enabled = false;
                    leftJump.GetComponent<SpriteRenderer>().enabled = false;
                    if (idle.GetComponent<SpriteRenderer>().flipX == false)
                    {
                        idle.GetComponent<SpriteRenderer>().flipX = true;
                    }
                    if (rightJump.GetComponent<SpriteRenderer>().flipX == false)
                    {
                        rightJump.GetComponent<SpriteRenderer>().flipX = true;
                    }
                }
                else
                {
                    idle.GetComponent<SpriteRenderer>().enabled = false;
                    rightMove.GetComponent<SpriteRenderer>().enabled = false;
                    leftMove.GetComponent<SpriteRenderer>().enabled = false;
                    rightJump.GetComponent<SpriteRenderer>().enabled = false;
                    leftJump.GetComponent<SpriteRenderer>().enabled = true;
                    if (idle.GetComponent<SpriteRenderer>().flipX == false)
                    {
                        idle.GetComponent<SpriteRenderer>().flipX = true;
                    }
                    if (rightJump.GetComponent<SpriteRenderer>().flipX == false)
                    {
                        rightJump.GetComponent<SpriteRenderer>().flipX = true;
                    }
                }
            }

            if ((Input.GetButtonDown("Jump") || Input.GetKeyDown("w")) && IsGrounded)
            {
                rb.AddForce(new Vector2(rb.velocity.x, jump * 10));
            }
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
        if (other.gameObject.CompareTag("Ground")) //initiantes cayote time once leaving the ground
        {
            cayote = true;

        }
    }
}
