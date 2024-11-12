using System.Collections.Generic;
using UnityEngine;

public class LeftRightPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float distanceOneWay;
    float startX;
    float halfSizeX;
    int randomIndex;
    public List<Vector2> targetPositions = new List<Vector2>();
    Vector2 currentTarget;
    Vector2 targetPos;

    void Start()
    {
        //goingUp = true;

        rb = GetComponent<Rigidbody2D>();
        startX = rb.position.x;
        halfSizeX = transform.localScale.x / 2;
        // Randomize start direction

        targetPositions.Add(new Vector2(rb.position.x + distanceOneWay, rb.position.y));
        targetPositions.Add(new Vector2(rb.position.x - distanceOneWay, rb.position.y));

        randomIndex = Random.Range(0, targetPositions.Count);
        currentTarget = targetPositions[randomIndex];

        targetPos.x = rb.position.x;
        targetPos.y = rb.position.y;
    }

    void FixedUpdate()
    {
        MoveLeftAndRight();
    }

    public void MoveLeftAndRight()
    {

        if (Mathf.Abs(currentTarget.x - rb.position.x) < 5f) //(0.9f * halfSizeX))
        {
            randomIndex = (randomIndex + 1) % targetPositions.Count;
            currentTarget = targetPositions[randomIndex];
        }

        if (startX <= currentTarget.x)
        {
            targetPos.x += Time.fixedDeltaTime * speed;
        }
        else
        {
            targetPos.x -= Time.fixedDeltaTime * speed;
        }
        
        rb.position = targetPos;
        //rb.MovePosition(targetPos);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(new Vector3(targetPos.x, startX, transform.position.z), new Vector3(transform.localScale.x, distanceOneWay, transform.localScale.z));
    }
}
