using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeTrap : MonoBehaviour
{
    [Header("Player")]
    // To be continued
    [SerializeField] int damage;
    [SerializeField] Transform respawnPoint;
    [Header("Movement")]
    [SerializeField] bool isMoving;
    [SerializeField] float initialDelay;
    [SerializeField] float speed;
    [SerializeField] Vector2 direction;
    Rigidbody2D rb;
    Vector2 targetPos;

    float timer = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPos = rb.position;
        direction = direction.normalized;
    }

    void Update()
    {
        if(timer < initialDelay)
        {
            timer += Time.deltaTime;
        }

        if(isMoving & timer >= initialDelay)
        {
            Move();
        }
    }

    private void Move()
    {
        targetPos += direction * Time.fixedDeltaTime * speed;
        rb.MovePosition(targetPos);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //other.GetComponent<PlayerHp>().ChangeHp(-damage);
            //StartCoroutine(other.GetComponent<Respawn>().RespawnCoroutine(this.respawnPoint));
            //Teleport player to a place close to the edge
        }
    }
}
