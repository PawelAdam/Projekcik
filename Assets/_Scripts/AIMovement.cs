using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float Speed;
    public float jumpForce;
    private bool isGrounded;
    public int Direction;
    private float DirectionTime;
    private float CollisionTime;
    private int CollisionCount;
    public bool GroundedJump;
    private float lastJumpTime;
    private float lastJumpAfterNullCollision;

    // Use this for initialization
    void Start()
    {
        CollisionTime = 0.0f;
        DirectionTime = 0;
        CollisionCount = 0;
        lastJumpTime = 0.0f;
        isGrounded = false;
        lastJumpTime = Time.time;
        lastJumpAfterNullCollision = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (CollisionCount == 0)
        {
            CollisionTime = 0.0f;
        }
        if (DirectionTime > 0)
        {
            if (Direction > 0)
            {
                transform.Translate(new Vector3(Speed * Time.deltaTime, 0, 0));
            }
            else
            {
                transform.Translate(new Vector3(-Speed * Time.deltaTime, 0, 0));
            }
            DirectionTime -= Time.deltaTime;
        }
        else
        {
            Direction = Random.Range(0, 2);
            DirectionTime = Random.Range(2.5f, 4.0f);
        }

        if(CollisionTime > 0.4f)
        {
            if (Direction == 0)
                Direction = 1;
            else
                Direction = 0;
            DirectionTime = Random.Range(2.5f, 4.0f);
            CollisionTime = 0;
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            CollisionCount++;

            if (!GroundedJump)
            {
                isGrounded = false;
                transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            }
            else
            {
                if (isGrounded)
                {
                    if (collision.gameObject.tag == "Ground")
                    {
                        isGrounded = false;
                        if (Time.time > lastJumpTime + 0.4324f)
                        {
                            lastJumpTime = Time.time;
                            transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
                        }
                    }
                }

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            CollisionCount--;
        if(CollisionCount == 0 && isGrounded && Time.time > lastJumpAfterNullCollision + 2.0f)
        {
            lastJumpAfterNullCollision = Time.time;
            transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            CollisionTime += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
          isGrounded = true;
    }
}
