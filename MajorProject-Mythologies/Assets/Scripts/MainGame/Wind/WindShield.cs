using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindShield : MonoBehaviour
{
    [SerializeField] AreaEffector2D effector;
    [SerializeField] float counterForce;

    void Start()
    {
        effector.forceMagnitude = 0f;
        //effector.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.tag == "Player" & LevelManager.Instance.isWindy) // & is windy
    //    {
    //        effector.forceMagnitude = counterForce;
    //        //effector.gameObject.SetActive(true);
    //    }
    //}
    //
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "Player" & LevelManager.Instance.isWindy) // & is windy
    //    {
    //        effector.forceMagnitude = counterForce;
    //        //effector.gameObject.SetActive(true);
    //    }
    //}
    //
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player") // & is windy
    //    {
    //        effector.forceMagnitude = 0f;
    //        //effector.gameObject.SetActive(false);
    //    }
    //}
}
