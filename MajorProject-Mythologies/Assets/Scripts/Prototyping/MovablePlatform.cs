using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    [SerializeField] float moveAmount;
    [SerializeField] float activationDistance;

    GameObject player;
    MoveDirection direction;
    Rigidbody rb;

    Color startColor;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        startColor = this.GetComponent<Renderer>().material.color;
    }

    
    void Update()
    {
        if((player.transform.position - this.transform.position).magnitude < activationDistance)
        {
            ChangeColor(Color.green);

           if(Input.GetMouseButtonDown(0))
           {
                Move(direction);
           }
        }
        else
        {
            ChangeColor(startColor);
        }

        // Up and down impact
        if (player.transform.position.y < this.transform.position.y)
        {
            this.direction = MoveDirection.Up;
        }
        else
        {
            this.direction = MoveDirection.Down;
        }
    }

    public void Move(MoveDirection direction)
    {
        Vector3 movementVector = Vector3.zero;

        switch (direction)
        {
            case MoveDirection.Left:
                movementVector = -transform.right;              
                break;
            case MoveDirection.Right:
                movementVector = transform.right;
                break;
            case MoveDirection.Up:
                movementVector = transform.up;
                break;
            case MoveDirection.Down:
                movementVector = -transform .up;
                break;
        }

        //rb.AddForce(movementVector * moveAmount, ForceMode.Impulse);
        transform.position += (movementVector * moveAmount);
    }

    void ChangeColor(Color color)
    {
        this.GetComponent<Renderer>().material.color = color;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(this.transform.position, new Vector3(1f,1f,1f) * activationDistance);
    }
}


public enum MoveDirection
{
    Up, Down, Left, Right
}
