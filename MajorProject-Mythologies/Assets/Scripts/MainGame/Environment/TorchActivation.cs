using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchActivation : MonoBehaviour
{
    [SerializeField] bool isOff;
    [SerializeField] AudioSource source;
    [SerializeField] Light lightSource;
    [SerializeField] ParticleSystem torchLightParticles;

    void Start()
    {
        if (!isOff)
        {
            lightSource.enabled = true;
            torchLightParticles.Play();
        }
        else
        {
            lightSource.enabled = false;
            torchLightParticles.Stop();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((isOff) & collision.gameObject.tag == "Player")
        {
            isOff = false;
            lightSource.enabled = true;
            source.Play();
            torchLightParticles.Play(true);
        }
    }
}
