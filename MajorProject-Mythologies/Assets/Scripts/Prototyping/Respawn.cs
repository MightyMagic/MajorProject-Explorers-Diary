using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public bool isRespawning = false;
    public IEnumerator RespawnCoroutine(Transform respawnPoint)
    {
       

        //this.gameObject.GetComponent<SimpleMovement>().enabled = false;
        this.gameObject.transform.position = respawnPoint.position;
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        yield return new WaitForSeconds(1f);

        //this.gameObject.GetComponent<SimpleMovement>().enabled = true;

        //yield return new WaitForEndOfFrame();
    }
}
