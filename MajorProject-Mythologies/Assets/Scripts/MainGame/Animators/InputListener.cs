using UnityEngine;

public class InputListener : MonoBehaviour
{
    Animator animator;

    float xInput;
    

    bool IsGrounded = true;

    private Vector2 rayOriginOffset = Vector2.zero;
    [SerializeField] private float rayLength = 5f;
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

        if(Input.GetButtonDown("Jump") && IsGrounded)
        {
            animator.SetBool("Jumping", true);
        }

       

        
    }

    private void CheckGrounded()
    {
        Vector2 rayOrigin = (Vector2)transform.position + rayOriginOffset; // Calculate ray origin with offset
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, rayLength, groundLayer);

        // Perform the raycast
        //IsGrounded = Physics.Raycast(ray, rayLength, groundLayer);
        IsGrounded = hit.collider != null;

        // Debugging (optional): Visualize the ray in the Scene view
        Debug.DrawRay(rayOrigin, Vector3.down * rayLength, IsGrounded ? Color.green : Color.red);

        animator.SetBool("Grounded", IsGrounded);
    }


}
