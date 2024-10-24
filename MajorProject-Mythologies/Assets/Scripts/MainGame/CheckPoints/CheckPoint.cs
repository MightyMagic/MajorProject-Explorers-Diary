using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();

    [SerializeField] int spawnIndex;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject cameraObj;

    void Start()
    {
        if (PlayerPrefs.HasKey("Spawn"))
        {
            playerObject.transform.position = spawnPoints[PlayerPrefs.GetInt("Spawn")].position;
            cameraObj.transform.position = playerObject.transform.position + new Vector3 (0, 0.55f, -20f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("Spawn", spawnIndex);
    }
}
