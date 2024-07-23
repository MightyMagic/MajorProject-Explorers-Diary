using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float followSpeed;
    [SerializeField] float distanceToFollow;
    Vector3 startVector;
    void Start()
    {
        startVector = transform.position - player.transform.position;
    }

    void Update()
    {
        SoftFollow();
    }

    void TeleportFollow()
    {
        transform.position = startVector + player.transform.position;
    }

    void SoftFollow()
    {
        Vector3 targetPos = startVector + player.transform.position;

        //if(Mathf.Abs(targetPos.x - transform.position.x) > distanceToFollow)
        //{
        //   // float newX = Mathf.Lerp(transform.position.x, targetPos.x, followSpeed * Time.deltaTime);
        //    transform.position = Vector3.MoveTowards(transform.position, targetPos, followSpeed * Time.deltaTime);
        //}

        if ((targetPos - transform.position).magnitude > distanceToFollow)
        {
            // float newX = Mathf.Lerp(transform.position.x, targetPos.x, followSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, followSpeed * Time.deltaTime);
        }
    }
}
