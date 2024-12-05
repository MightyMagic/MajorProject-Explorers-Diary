using UnityEngine;

public class AnimationToPhysicsControls : MonoBehaviour
{
    Animator animator;
    Vector2 velocity;
    Rigidbody2D body;

    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponentInParent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        if(Mathf.Abs(velocity.x) > 0f)
        {
            body.linearVelocity = new Vector2(velocity.x * speed, body.linearVelocityY);
        }

       // if((Mathf.Abs(velocity.y) > 0f))
       // {
       //     body.linearVelocity = new Vector2(body.linearVelocityX, velocity.y * speed);
       // }

        body.interpolation = RigidbodyInterpolation2D.Interpolate;
    }
    private void OnAnimatorMove()
    {
        velocity = animator.deltaPosition/Time.deltaTime;
    }

    public void BeginJump()
    {
        body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        animator.SetBool("Jumping", false);
        body.gravityScale = 0f;
    }

    public void EndJump()
    {
        body.gravityScale = 3f;
    }
}
