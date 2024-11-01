using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatueAppearance : MonoBehaviour
{
    [SerializeField] TarodevController.PlayerController playerController;
    [SerializeField] TarodevController.PlayerStats standingState;
    [SerializeField] AudioSource mainAudioSource;
    [SerializeField] AudioClip statueIntro;

    [Header("Light")]
    [SerializeField] float duration;
    [SerializeField] Light statueLight;
    float initialIntensity;
    bool activated = false;

    // Dialogues
    [SerializeField] StatueDialog dialogLogic;

    void Start()
    {
        initialIntensity = statueLight.intensity;
        statueLight.intensity = 0f;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activated)
        {
            if(collision.gameObject.tag == "Player")
            {
                activated = true;

                mainAudioSource.Stop();
                mainAudioSource.clip = statueIntro;
                mainAudioSource.Play();

                StartCoroutine(ActivateStatue());
            }
        }
    }

    private IEnumerator ActivateStatue()
    {
        playerController.idleState = true;

        float startIntensity = statueLight.intensity;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            statueLight.intensity = Mathf.Lerp(startIntensity, initialIntensity, elapsedTime / duration);
            yield return null;
        }
        
        yield return new WaitForSeconds(1f);

        StartCoroutine(dialogLogic.PlayNextPhrase());
    }

    public void RegainPlayerControl()
    {
        playerController.idleState = false;
        SceneManager.LoadScene(2);
    }
}
