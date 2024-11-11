using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimSimple : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject playerModel;
    [SerializeField] Animator animator;
    void Start()
    {
        
    }

    void Update()
    {
        if (animator.GetBool("Blocking") == true)
        {
            animator.SetBool("Blocking", false);
            playerModel.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        }

        if (Mathf.Abs(rb.linearVelocity.x) > 0.5f)
        {
            if (animator.GetBool("Walking") == false)
            {
                animator.SetBool("Walking", true);
            }

            if (rb.linearVelocity.x > 0.2f)
            {
                playerModel.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            }
            else
            {
                playerModel.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            }
        }
        else
        {
            if (animator.GetBool("Walking") == true)
            {
                animator.SetBool("Walking", false);
            }

            playerModel.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        }
    }
}
