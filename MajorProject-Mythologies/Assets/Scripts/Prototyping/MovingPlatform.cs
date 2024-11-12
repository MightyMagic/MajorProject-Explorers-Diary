using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] List<Transform> platforms = new List<Transform>();
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] float proximityDistance;

    int currentIndex = 1;
    void Start()
    {
        
    }

    void Update()
    {
        MoveBetweenPoints();
    }

    public void MoveBetweenPoints()
    {
        if((rb.position - platforms[currentIndex].position).magnitude > proximityDistance)
        {
            Vector3 vel = (-rb.position + platforms[currentIndex].position).normalized * speed;

            rb.linearVelocity = vel;
        }
        else
        {
            currentIndex = (currentIndex + 1) % platforms.Count;
        }
    }
}
