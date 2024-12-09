using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class SpikeTrapFloor : MonoBehaviour
{
    [SerializeField] float initialDelay;
    [SerializeField] float maxYCoordinate;
    [SerializeField] float speed;

    public bool startMoving = false;
    public float yDiff = 0f;

    void Start()
    {
        StartCoroutine(StartMoving());
    }

    void Update()
    {
        if (startMoving)
        {
            yDiff += speed * Time.deltaTime;

            if(this.gameObject.transform.position.y < maxYCoordinate)
            {
                this.transform.position += transform.up * speed * Time.deltaTime;
            }
        }
    }

    IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(initialDelay);
        startMoving = true;
    }
}
