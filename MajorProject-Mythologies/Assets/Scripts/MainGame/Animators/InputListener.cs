using UnityEngine;

public class InputListener : MonoBehaviour
{
    Animator animator;

    float xInput;
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
    }


}
