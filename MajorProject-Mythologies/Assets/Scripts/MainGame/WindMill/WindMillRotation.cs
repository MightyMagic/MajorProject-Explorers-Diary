using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMillRotation : MonoBehaviour
{
    [SerializeField] List<GameObject> cylinders = new List<GameObject>();
    private float rotationSpeed;

    public void ChangeRotation(float rotationSpeed)
    {
        this.rotationSpeed = rotationSpeed;
    }

    void RotateWindMill()
    {
        foreach (GameObject cylinder in cylinders)
        {
            cylinder.transform.Rotate(Vector3.up * this.rotationSpeed * Time.deltaTime);
        }
    }
   
    void Start()
    {
        //cylinder.transform.rotation = Quaternion.Euler(0f, -90f, -90f);
        ChangeRotation(5f);
    }

   
    void Update()
    {
        if(Mathf.Abs(this.rotationSpeed) > 0f)
        {
            RotateWindMill();
        }
    }
}
