using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class Lever : MonoBehaviour
{
    GameObject player;
    [SerializeField] float activationDistance;

    [SerializeField] List<InteractiveObject> actionTargets;

    bool playerNear = false;
    bool activated = false;

    [SerializeField] TextMeshProUGUI PressMeText;
    [SerializeField] GameObject leverBody;

    [SerializeField] float resetTiming;
    
    void Start()
    {
        player = GameObject.Find("PlayerMain");
        PressMeText.text = "Press E";
        PressMeText.gameObject.SetActive(false);
    }

   
    void Update()
    {
        // Check if player is near the lever
        if((player.transform.position - this.transform.position).magnitude < activationDistance)
        {
            if(!playerNear & !activated)
            {
                PressMeText.gameObject.SetActive(true);
                playerNear = true;
            }
        }
        else
        {
            if(playerNear)
            {
                PressMeText.gameObject.SetActive(false);
                playerNear = false;
            }
        }

        if (playerNear & UnityEngine.Input.GetKeyDown(KeyCode.E) & !activated)
        {
            Activate();
        }
    }

    void Activate()
    {
        Debug.LogError("The level triggered something");
        // Animate
        if(!activated)
        {
            activated = true;
            StartCoroutine(RotateOverTime(3f));

            // Execute action
            for (int i = 0; i < actionTargets.Count; i++)
            {
                actionTargets[i].TriggerAction();
            }

            //StartCoroutine(ResetLever());
        }

    }

    IEnumerator ResetLever()
    {
        yield return new WaitForSeconds(resetTiming);

        Quaternion startRotation = leverBody.transform.rotation;
        Debug.LogError("Start Rotation is " + leverBody.transform.rotation.eulerAngles.x + " , " + leverBody.transform.rotation.eulerAngles.y + " , " + leverBody.transform.rotation.eulerAngles.z);
        Quaternion endRotation = Quaternion.Euler(-40f, 90f, 0);
        float elapsedTime = 0f;

        while (elapsedTime < 3f)
        {
            //leverBody.transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / rotationDuration);
            //float xDiff = (endRotation.eulerAngles.x - startRotation.eulerAngles.x) * (elapsedTime / rotationDuration);
            float xDiff = 0.07f;
            leverBody.transform.rotation *= Quaternion.Euler(xDiff, 0f, 0f);
            elapsedTime += Time.deltaTime;
            yield return null;
            //yield return new WaitForEndOfFrame();
        }

        PressMeText.gameObject.SetActive(false);
        leverBody.transform.rotation = endRotation;
        
    }

    IEnumerator RotateOverTime(float rotationDuration)
    {
        Quaternion startRotation = leverBody.transform.rotation;
        Debug.LogError("Start Rotation is " + leverBody.transform.rotation.eulerAngles.x + " , " + leverBody.transform.rotation.eulerAngles.y + " , " + leverBody.transform.rotation.eulerAngles.z);
        Quaternion endRotation = Quaternion.Euler(-130f, 90f, 0);
        float elapsedTime = 0f;

        while (elapsedTime < rotationDuration)
        {
            //leverBody.transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / rotationDuration);
            //float xDiff = (endRotation.eulerAngles.x - startRotation.eulerAngles.x) * (elapsedTime / rotationDuration);
            float xDiff = -0.07f;
            leverBody.transform.rotation *= Quaternion.Euler(xDiff, 0f, 0f);
            elapsedTime += Time.deltaTime;
            yield return null;
            //yield return new WaitForEndOfFrame();
        }

        PressMeText.gameObject.SetActive(false);
        leverBody.transform.rotation = endRotation;

        startRotation = leverBody.transform.rotation;
        Debug.LogError("Start Rotation is " + leverBody.transform.rotation.eulerAngles.x + " , " + leverBody.transform.rotation.eulerAngles.y + " , " + leverBody.transform.rotation.eulerAngles.z);
        endRotation = Quaternion.Euler(-40f, 90f, 0);
        elapsedTime = 0f;

        while (elapsedTime < 3f)
        {
            //leverBody.transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / rotationDuration);
            //float xDiff = (endRotation.eulerAngles.x - startRotation.eulerAngles.x) * (elapsedTime / rotationDuration);
            float xDiff = 0.07f;
            leverBody.transform.rotation *= Quaternion.Euler(xDiff, 0f, 0f);
            elapsedTime += Time.deltaTime;
            yield return null;
            //yield return new WaitForEndOfFrame();
        }

        PressMeText.gameObject.SetActive(false);
        leverBody.transform.rotation = endRotation;

        activated = false;

        //actionTarget.TriggerAction();
    }
}

public enum LeverAction
{
    UnlockDoor,
    StopTrap,
    None
}
