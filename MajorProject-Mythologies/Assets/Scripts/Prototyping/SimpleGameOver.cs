using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleGameOver : MonoBehaviour
{
    float startY;
    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        if(startY - transform.position.y > 20f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
