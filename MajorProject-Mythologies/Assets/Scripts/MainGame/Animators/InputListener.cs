using UnityEngine;

public class InputListener : MonoBehaviour
{
    Animator animator;

    float xInput;
    

    bool IsGrounded = true;

    private Vector2 rayOriginOffset = Vector2.zero;
    [SerializeField] private float rayLength = 5f;
    [SerializeField] private float rayXoffset;
    [SerializeField] private LayerMask groundLayer;

    Vector3 leftRotation;
    Vector3 rightRotation;

    bool left = true;
    
    void Start()
    {
        animator = GetComponent<Animator>();

        leftRotation = this.transform.eulerAngles;
        rightRotation = new Vector3(leftRotation.x, leftRotation.y + 180f, leftRotation.z);

    }

    
    void Update()
    {
        xInput = -Input.GetAxis("Horizontal");
        

        if(Mathf.Abs(xInput) > 0.05f)
        {
            animator.SetBool("moving", true);

            if(xInput > 0.05f & !left)
            {
                left = true;
                Debug.LogError("Turning left!");
                this.transform.rotation = Quaternion.Euler(leftRotation);
            }
            else if(xInput < -0.05f & left)
            {
                left = false;
                Debug.LogError("Turning right");
                this.transform.rotation = Quaternion.Euler(rightRotation);
            }
        }
        else
        {
            animator.SetBool("moving", false);
        }

        CheckGrounded();

        if(Input.GetButtonDown("Jump"))
        {
            if (IsGrounded)
            {
                animator.SetBool("Jumping", true);

            }

            animator.SetInteger("JumpCounter", animator.GetInteger("JumpCounter") + 1);
        }
    }

    public float XInput()
    {
        return xInput;
    }

    private void CheckGrounded()
    {
        Vector2 rayLeft = (Vector2)transform.position + new Vector2(-rayXoffset, 0f);
        Vector2 rayRight = (Vector2)transform.position + new Vector2(rayXoffset, 0f);
        Vector2 rayOrigin = (Vector2)transform.position + rayOriginOffset; // Calculate ray origin with offset
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, rayLength, groundLayer);
        RaycastHit2D hitLeft = Physics2D.Raycast(rayLeft, Vector2.down, rayLength, groundLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(rayRight, Vector2.down, rayLength, groundLayer);

        // Perform the raycast
        //IsGrounded = Physics.Raycast(ray, rayLength, groundLayer);
        IsGrounded = hit.collider != null || hitLeft.collider != null || hitRight.collider != null;

        // Debugging (optional): Visualize the ray in the Scene view
        Debug.DrawRay(rayOrigin, Vector3.down * rayLength, IsGrounded ? Color.green : Color.red);

        animator.SetBool("Grounded", IsGrounded);

        //if(IsGrounded)
        //{
        //    if (animator.GetInteger("JumpCounter") > 0)
        //    {
        //        animator.SetInteger("JumpCounter", 0);
        //    }
        //}
    }

    private void OnDrawGizmos()
    {
        // Calculate ray positions
        Vector2 rayOrigin = (Vector2)transform.position + rayOriginOffset;
        Vector2 rayLeft = (Vector2)transform.position + new Vector2(-rayXoffset, 0f);
        Vector2 rayRight = (Vector2)transform.position + new Vector2(rayXoffset, 0f);

        // Draw rays in the scene view
        Debug.DrawRay(rayOrigin, Vector2.down * rayLength, Color.red); // Central ray
        Debug.DrawRay(rayLeft, Vector2.down * rayLength, Color.green); // Left ray
        Debug.DrawRay(rayRight, Vector2.down * rayLength, Color.blue); // Right ray

        // Optionally, visualize the raycast hits
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, rayLength, groundLayer);
        RaycastHit2D hitLeft = Physics2D.Raycast(rayLeft, Vector2.down, rayLength, groundLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(rayRight, Vector2.down, rayLength, groundLayer);

        if (hit.collider != null)
            Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(hit.point, 0.1f);

        if (hitLeft.collider != null)
            Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(hitLeft.point, 0.1f);

        if (hitRight.collider != null)
            Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(hitRight.point, 0.1f);
    }
}
