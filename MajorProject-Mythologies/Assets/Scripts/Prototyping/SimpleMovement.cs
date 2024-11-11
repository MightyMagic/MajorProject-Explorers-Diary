using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    Rigidbody2D playerRb;
    [SerializeField] Direction startDirection;

    [Header("Movement properties")]
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    Direction currentDirection;
    public bool ableToJump = true;
    float timeOfJump;
    public int jumpCount = 0;
    [SerializeField] float jumpTimer;

    [SerializeField] Animator  animator;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        ChangeDirection(Direction.Left, -1);

        animator.SetBool("Walking", false);
    }

    void Update()
    {
        CheckDirection();
        MoveForward();

        if (Input.GetKeyDown(KeyCode.Space) & (ableToJump || ((Time.time - timeOfJump) < jumpTimer) & jumpCount < 2))
        {
            Jump();
        }
    }

    void MoveForward()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.3f)
        {
            Vector3 vel = transform.forward * speed * (-1);
            playerRb.linearVelocity = new Vector3(vel.x, playerRb.linearVelocity.y, vel.z);

            if (!animator.GetBool("Walking"))
            {
                animator.SetBool("Walking", true);
            }
        }
       
    }

    void ChangeDirection(Direction direction, int rotation)
    {
        if(direction == Direction.Left)
        {
            currentDirection = Direction.Right;
        }
        else
        {
            currentDirection = Direction.Left;
        }

        this.transform.rotation = Quaternion.Euler(0f, 90f * rotation, 0f);
    }

    void CheckDirection()
    {
        if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.3f)
        {
            if(Input.GetAxis("Horizontal") > 0f)
            {
                ChangeDirection(Direction.Left, -1);
            }
            else
            {
                ChangeDirection(Direction.Right, 1);
            }

            //MoveForward();
        }
        else
        {
            //playerRb.velocity = new Vector3(0f, playerRb.velocity.y, 0f);//Vector3.zero;

            if (animator.GetBool("Walking"))
            {
                animator.SetBool("Walking", false);
            }
        }
    }

    void Jump()
    {
        ableToJump = false;
        timeOfJump = Time.time;
        jumpCount += 1;

        playerRb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!ableToJump)
        {
            ableToJump = true;
            jumpCount = 0;
        }
    }
}

public enum Direction
{
    Left,
    Right
}
