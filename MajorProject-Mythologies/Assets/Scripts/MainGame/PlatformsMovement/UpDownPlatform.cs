using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownPlatform : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float distanceOneWay;
    float startY;
    float halfSizeY;
    int randomIndex;
    List<Vector2> targetPositions = new List<Vector2>();
    Vector2 currentTarget;
    Vector2 targetPos;

    void Start()
    {
        //goingUp = true;

        rb = GetComponent<Rigidbody2D>();
        startY = rb.position.y;
        halfSizeY = transform.localScale.y / 2;
        // Randomize start direction

        targetPositions.Add(new Vector2(rb.position.x, rb.position.y + distanceOneWay));
        targetPositions.Add(new Vector2(rb.position.x, rb.position.y - distanceOneWay));

        randomIndex = Random.Range(0, targetPositions.Count);
        currentTarget = targetPositions[randomIndex];

        targetPos.x = rb.position.x;
        targetPos.y = rb.position.y;
    }

    void FixedUpdate()
    {
        MoveUpAndDown();
    }

    public void MoveUpAndDown()
    {

        if(Mathf.Abs(currentTarget.y - rb.position.y) < (0.9f * halfSizeY))
        {
            randomIndex = (randomIndex + 1) % targetPositions.Count;
            currentTarget = targetPositions[randomIndex];
        }
        
        if(startY <= currentTarget.y)
        {
            targetPos.y +=  Time.fixedDeltaTime * speed;
        }
        else
        {
            targetPos.y -= Time.fixedDeltaTime * speed;
        }

        rb.MovePosition(targetPos);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(new Vector3(targetPos.x, startY, transform.position.z), new Vector3(transform.localScale.x, distanceOneWay, transform.localScale.z));
    }
}
