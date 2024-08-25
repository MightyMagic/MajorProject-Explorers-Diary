using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravellingPlatform : MonoBehaviour
{
    [SerializeField] List<Transform> checkpoints;
    [SerializeField] GameObject mainPlatform;

    [SerializeField] float speed;
    [SerializeField] float comebackTimer;

    [SerializeField] float cutoffDistance
        ;
    [SerializeField] float activationDistance;

    public List<Transform> dynamicCheckpoints = new List<Transform>();
    GameObject player;
    bool finishedTravelling = false;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if ((player.transform.position - mainPlatform.transform.position).magnitude < activationDistance)
        {

        }
        else
        {

        }
    }

    void AcquireCheckpoints()
    {
        dynamicCheckpoints.Clear();

        for(int i = 0; i < checkpoints.Count; i++)
        {
            dynamicCheckpoints.Add(checkpoints[i]);
        }
    }

    public void TravelForward()
    {
        if(dynamicCheckpoints.Count > 0 & !finishedTravelling)
        {
            Vector3 direction = (dynamicCheckpoints[0].position - transform.position);
            if(direction.magnitude > cutoffDistance)
            {
                this.transform.position += direction.normalized * Time.deltaTime * speed;
            }
            else
            {
                dynamicCheckpoints.RemoveAt(0);
            }

        }
        else
        {
            finishedTravelling = true;
        }
    }

    public void TravelBack()
    {

    }
}
