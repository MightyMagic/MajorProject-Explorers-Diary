using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] Transform respawnPoint;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerHp>().ChangeHp(-damage);
            StartCoroutine(other.GetComponent<Respawn>().RespawnCoroutine(this.respawnPoint));
            //Teleport player to a place close to the edge
        }
    }
}
