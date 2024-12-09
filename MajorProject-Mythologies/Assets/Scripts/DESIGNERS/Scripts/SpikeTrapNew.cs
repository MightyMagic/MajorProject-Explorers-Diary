using System.Collections;
using UnityEngine;

public class SpikeTrapNew : MonoBehaviour
{
    [Header("Timings")]
    [SerializeField] float initialDelay;
    [SerializeField] float spikesUpTime;
    [SerializeField] float spikesCooldown;

    [Header("Motion properties")]
    [SerializeField] float spikesUpSpeed;
    [SerializeField] float spikesDownSpeed;
    //[SerializeField] AudioClip spikesSound;
    [SerializeField] GameObject spikesObject;
    [SerializeField] float spikesDistance;
    float initialSpikePosition;
    float currentSpikePosition;

    [Header("SpikeTrapFloor")]
    [SerializeField] SpikeTrapFloor floorScript;

    void Start()
    {
        initialSpikePosition = spikesObject.transform.position.y;
        currentSpikePosition = initialSpikePosition;

        StartCoroutine(SpikeTrapCoroutine());
    }

    void Update()
    {
        if(floorScript != null)
        {
            if(floorScript.startMoving)
            {
                currentSpikePosition = initialSpikePosition + floorScript.yDiff;
            }
        }
    }

    IEnumerator SpikeTrapCoroutine()
    {
        yield return new WaitForSeconds(initialDelay);

        while(true)
        {
            while (spikesObject.transform.position.y < currentSpikePosition + spikesDistance)
            {
                spikesObject.transform.position += transform.forward * spikesUpSpeed * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(spikesUpTime);

            while (spikesObject.transform.position.y > currentSpikePosition)
            {
                spikesObject.transform.position -= transform.forward * spikesDownSpeed * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(spikesCooldown);
        }
    }
}
