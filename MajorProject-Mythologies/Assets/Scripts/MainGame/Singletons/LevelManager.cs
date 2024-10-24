using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [Header("Wind")]
    public bool isWindy;
    [SerializeField] float windCoolDown;
    //[SerializeField] WindScript windScript;

    [SerializeField] List<ParticleSystem> windParticles;
    [SerializeField] List<AreaEffector2D> windAffectors;
    [SerializeField] List<AreaEffector2D> windShieldAffector;
    [SerializeField] float windDuration;

    [SerializeField] float windForce;
    

    public float timer = 0f;

    [Header("Sfx")]
    [SerializeField] AudioSource windAudioSource;
    [SerializeField] AudioClip windClip;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        isWindy = false;

        windAudioSource.clip = windClip;

        foreach(AreaEffector2D effector in windAffectors)
        {
            effector.forceMagnitude = 0f;
        }

        foreach(AreaEffector2D effector in windShieldAffector)
        {
            effector.forceMagnitude = 0f;
        }

        foreach(ParticleSystem particle in windParticles)
        {
            particle.Stop();
        }

    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > windCoolDown &&isWindy==false)
        {
            isWindy=true;
            timer = 0f;
            StartCoroutine(WindCoroutineNew());
            //LaunchWind();
        }
    }

    public IEnumerator WindCoroutineNew()
    {
        foreach (ParticleSystem particle in windParticles)
        {
            particle.Play();
        }

        windAudioSource.Play();

        yield return new WaitForSeconds(1f);

        //windAffector.forceMagnitude = windForce;

        foreach (AreaEffector2D effector in windAffectors)
        {
            effector.forceMagnitude = windForce;
        }

        //windShieldAffector.forceMagnitude = -windForce;

        foreach (AreaEffector2D effector in windShieldAffector)
        {
            effector.forceMagnitude = -windForce;
        }

        //LevelManager.Instance.isWindy = true;
        //windAffector.gameObject.SetActive(true);


        yield return new WaitForSeconds(windDuration - 1f);

        foreach (ParticleSystem particle in windParticles)
        {
            particle.Stop();
        }

        yield return new WaitForSeconds(1f);

        windAudioSource.Stop();

        isWindy = false;
        //windAffector.gameObject.SetActive(false);
        //windAffector.forceMagnitude = 0f;
        //windShieldAffector.forceMagnitude = 0f;

        foreach (AreaEffector2D effector in windAffectors)
        {
            effector.forceMagnitude = 0f;
        }

        foreach (AreaEffector2D effector in windShieldAffector)
        {
            effector.forceMagnitude = 0f;
        }


        timer = 0f;
        isWindy = false;
    }

}
