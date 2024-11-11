using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField] LeverAction actionType;
    [SerializeField] Animator animator;
    bool activated = false;

    public void TriggerAction()
    {
        if(actionType == LeverAction.UnlockDoor)
        {
            animator.SetBool("Open", true);
        }
        else if(actionType == LeverAction.StopTrap)
        {
            AxeTrap axeTrap = this.gameObject.GetComponent<AxeTrap>();
            if(axeTrap != null)
            {
                axeTrap.StopRotation();
                StartCoroutine(axeTrap.ResumeRotation());
            }
        }
    }
}
