using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{
    [SerializeField] ParticleSystem windParticles;
    [SerializeField] AreaEffector2D windAffector;
    [SerializeField] AreaEffector2D windShieldAffector;
    [SerializeField] float windDuration;

    [SerializeField] float windForce;
    void Start()
    {
        windAffector.forceMagnitude = 0f;
        windShieldAffector.forceMagnitude = 0f;
        windParticles.Stop();
        //windAffector.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public IEnumerator WindCoroutine()
    {
        windParticles.gameObject.SetActive(true);
        windParticles.Play();

        yield return new WaitForSeconds(2.0f);

        windAffector.forceMagnitude = windForce;
        LevelManager.Instance.isWindy = true;
        //windAffector.gameObject.SetActive(true);


        yield return new WaitForSeconds(windDuration);

        LevelManager.Instance.isWindy = false;
        //windAffector.gameObject.SetActive(false);
        windAffector.forceMagnitude = 0f;
        windParticles.Stop();

    }

    public IEnumerator WindCoroutineNew()
    {
        windParticles.Play();
        windShieldAffector.forceMagnitude = -windForce;

        //yield return new WaitForSeconds(0.5f);

        windAffector.forceMagnitude = windForce;
        //LevelManager.Instance.isWindy = true;
        //windAffector.gameObject.SetActive(true);


        yield return new WaitForSeconds(windDuration);

        LevelManager.Instance.isWindy = false;
        //windAffector.gameObject.SetActive(false);
        windAffector.forceMagnitude = 0f;
        windShieldAffector.forceMagnitude = 0f;
        windParticles.Stop();

    }
}
