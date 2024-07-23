using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    Rigidbody playerRb;
    [SerializeField] float dashForce;
    [SerializeField] float dashCooldown;

    float timer;
    bool isDashing;
    bool canDash = true;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        DashCooldown();

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(canDash)
                PerformDash();
        }
    }

    void DashCooldown()
    {
        if(timer > dashCooldown)
        {
            canDash = true;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    void PerformDash()
    {
        canDash = false;
        timer = 0f;

        playerRb.AddForce(-playerRb.transform.forward * dashForce, ForceMode.VelocityChange);
    }
}
