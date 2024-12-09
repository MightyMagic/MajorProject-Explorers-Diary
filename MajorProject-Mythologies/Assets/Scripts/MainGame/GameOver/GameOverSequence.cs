using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSequence : MonoBehaviour
{
    [SerializeField] GameObject dyingMesh;
    [SerializeField] CinemachineBrain injuredCameraBrain;
    [SerializeField] CinemachineVirtualCamera gameOverCamera;

    [SerializeField] float duration;
    void Awake()
    {
        DisableAll();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && dyingMesh.gameObject.activeInHierarchy)
        {
            StopCoroutine(GameOverCoroutine());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    void DisableAll()
    {
        dyingMesh.gameObject.SetActive(false);
        injuredCameraBrain.gameObject.SetActive(false);
        gameOverCamera.Priority = 0;
    }

    void EnableAll()
    {
        dyingMesh.gameObject.SetActive(true);
        injuredCameraBrain.gameObject.SetActive(true);
        gameOverCamera.Priority = 20;
    }

    public void GameOver()
    {
        StartCoroutine(GameOverCoroutine());
    }

    IEnumerator GameOverCoroutine()
    {
        yield return null;
        EnableAll();
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
