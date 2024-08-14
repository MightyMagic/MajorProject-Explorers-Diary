using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage;
    [SerializeField] int direction;

    Vector3 startPos;
    Rigidbody rb;
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();

        if((startPos - transform.position).magnitude > 100f)
        {
            Destroy(this.gameObject);
        }
    }

    private void Move()
    {
        rb.velocity = transform.up * speed * direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerHp>().ChangeHp(damage);
            Destroy(this.gameObject);
        }
    }
}
