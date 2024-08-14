using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBox : MonoBehaviour
{
    [SerializeField] GameObject arrowObject;
    [SerializeField] float startTimer;
    [SerializeField] float frequency;
    float timer;
    void Start()
    {
        timer = startTimer;
    }

    void Update()
    {
        if(timer < frequency)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            Instantiate(arrowObject, this.transform.transform.position, Quaternion.Euler(0f,0f,90f));
        }
    }
}
