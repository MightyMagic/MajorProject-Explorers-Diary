using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FellOff : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float distanceToFall;
    float startY;
    private void Start()
    {
        startY = player.transform.position.y;
    }

    void Update()
    {
        if(player.transform.position.y - startY < -distanceToFall)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
