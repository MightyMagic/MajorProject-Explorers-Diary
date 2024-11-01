using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float pushForce = 10f;
    public float pushDuration = 1000f;

    private Rigidbody2D rb;

    public bool isAffectingPlayer = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") & isAffectingPlayer)
        {
            StartCoroutine(PushPlayer(other));
        }
        else
        {
            isAffectingPlayer = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    { 

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            isAffectingPlayer = true;
        }
        else
        {
            StopCoroutine(PushPlayer(collision));
        }
    }

    IEnumerator PushPlayer(Collider2D player)
    {
        Vector2 pushDirection = transform.right;
        float elapsedTime = 0f;

        //while (elapsedTime < pushDuration)
        //{
        //
        //}

        elapsedTime += Time.deltaTime;
        player.GetComponent<Rigidbody2D>().AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
        yield return null;
    }
}
