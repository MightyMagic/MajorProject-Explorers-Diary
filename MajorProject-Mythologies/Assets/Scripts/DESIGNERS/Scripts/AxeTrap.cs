using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeTrap : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] float maxAngle;

    [SerializeField] int direction;
    [SerializeField] float coolDownToReset;

    Rigidbody2D rb;

    float currentRotationSpeed;

    private bool hasSwitchedDirection = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentRotationSpeed = rotationSpeed;
        Debug.LogError("Current angle is " + (Mathf.Abs(this.transform.rotation.z)));
    }

    void FixedUpdate()
    {
        float currentAngle = Mathf.Abs(transform.eulerAngles.z);

        if (currentAngle > 180f)
        {
            currentAngle = 360f - currentAngle;
        }

        if (Mathf.Abs(currentAngle) < maxAngle)
        {
            Debug.LogError("Current angle is " + (Mathf.Abs(this.transform.rotation.z)));
           
            hasSwitchedDirection = false;
        }
        else if(!hasSwitchedDirection)
        {
            hasSwitchedDirection = true;
            direction *= -1;
        }

        this.transform.rotation *= Quaternion.Euler(transform.forward * currentRotationSpeed * direction * Time.deltaTime);
    }

    public void StopRotation()
    {
        currentRotationSpeed = 0f;
    }

    public IEnumerator ResumeRotation()
    {
        yield return new WaitForSeconds(coolDownToReset);
        currentRotationSpeed = rotationSpeed;
    }


}
