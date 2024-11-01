using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchBlend : MonoBehaviour
{
    //[SerializeField] CinemachineVirtualCamera mainCamera;
    [SerializeField] CinemachineBrain brain;    
    [SerializeField] CinemachineVirtualCamera triggeredCamera;
    [SerializeField] float blendDuration = 1f; // Duration of the blend

    //int initialMainPriority;
    int initialTriggerPriority;

    int currentPriority;

    private void Start()
    {
        
        //initialMainPriority = mainCamera.Priority;
        initialTriggerPriority = triggeredCamera.Priority;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && brain.ActiveVirtualCamera.Priority > triggeredCamera.Priority)
        {
            int priority = brain.ActiveVirtualCamera.Priority;
            brain.ActiveVirtualCamera.Priority = initialTriggerPriority;
            triggeredCamera.Priority = priority;
           
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        triggeredCamera.Priority = initialTriggerPriority;
    //        mainCamera.Priority =  initialMainPriority;
    //
    //    }
    //}

}
