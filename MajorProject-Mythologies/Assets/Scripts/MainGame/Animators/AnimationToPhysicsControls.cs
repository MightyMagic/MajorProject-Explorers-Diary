using UnityEngine;

public class AnimationToPhysicsControls : MonoBehaviour
{
    Animator animator;
    Vector2 velocity;
    Rigidbody2D body;

    [SerializeField] float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponentInParent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(velocity.magnitude > 0f)
        {
            body.linearVelocity = new Vector2(velocity.x * speed, body.linearVelocityY);

        }

        body.interpolation = RigidbodyInterpolation2D.Interpolate;
    }
    private void OnAnimatorMove()
    {
        velocity = animator.deltaPosition/Time.deltaTime;
    }
}
