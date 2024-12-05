using UnityEngine;

public class AnimationToPhysicsControls : MonoBehaviour
{
    Animator animator;
    Vector2 velocity;
    Rigidbody2D body;

    [SerializeField] float speed;
    [SerializeField] float airSpeed;
    [SerializeField] InputListener inputListener;

    [Header("Jump")]
    [SerializeField] float jumpForce;
    [SerializeField] float gravityScaleDown;

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
        else
        {
            if (!animator.GetBool("Grounded"))
            {
                body.linearVelocity = new Vector2(-inputListener.XInput() * airSpeed, body.linearVelocityY);
            }
        }

        body.interpolation = RigidbodyInterpolation2D.Interpolate;
    }
    private void OnAnimatorMove()
    {
        velocity = animator.deltaPosition/Time.deltaTime;
    }

    public void BeginJump()
    {
        body.linearVelocity = new Vector2 (velocity.x, 0f);
        body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        animator.SetBool("Jumping", false);
        body.gravityScale = 0f;
    }

    public void EndJump()
    {
        body.gravityScale = gravityScaleDown;
    }
}
