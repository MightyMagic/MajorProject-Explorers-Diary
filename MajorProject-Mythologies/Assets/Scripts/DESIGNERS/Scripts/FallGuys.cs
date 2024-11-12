using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class FallGuys : MonoBehaviour
{
    [SerializeField] List<FadingPlatforms> platformSets;
    [SerializeField] float fadeSpeed;

    [SerializeField] float initialDelay;
    [SerializeField] float swapSetsCoolDown;

    int currentIndex;
    void Start()
    {
        int randomIdex = UnityEngine.Random.Range(0, platformSets.Count);
        currentIndex = randomIdex;

        DisableAllSets();
        RestoreAllMaterials();
        ApplyAllMaterials();
        EnableSet(currentIndex);

        InvokeRepeating("SwapSets", initialDelay, swapSetsCoolDown);
    }

    void Update()
    {
        
    }

    void DisableAllSets()
    {
        for(int i = 0; i < platformSets.Count; i++)
        {
            for (int j = 0; j < platformSets[i].platformSet.Count; j++)
            {
                platformSets[i].platformSet[j].gameObject.SetActive(false);
            }
        }
    }

    void DisableSet(int index)
    {
        for (int i = 0; i < platformSets[index].platformSet.Count; i++)
        {
            platformSets[index].platformSet[i].gameObject.SetActive(false);
        }
    }

    void SwapSets()
    {
        StartCoroutine(EnableNextSet());
    }

    IEnumerator EnableNextSet()
    {
        EnableSet((currentIndex + 1) % platformSets.Count);
        DisableSetColliders((currentIndex + 1) % platformSets.Count);

        // Fade out Previous Set & Fade in next Set
        float fadeIn = 0.3f;
        float fadeOut = 1f;

        while(fadeIn < 1f && fadeOut > 0.1f)
        {
            yield return new WaitForEndOfFrame();
            fadeOut -= Time.deltaTime * fadeSpeed / 100f;
            fadeIn += Time.deltaTime * fadeSpeed / 100f;

            Color fadeOutColor = platformSets[currentIndex].materialSet.color;
            Color fadeInColor = platformSets[(currentIndex + 1) % platformSets.Count].materialSet.color;
           
            platformSets[currentIndex].materialSet.color = new Color(fadeOutColor.r, fadeOutColor.g, fadeOutColor.b, fadeOut);
            platformSets[(currentIndex + 1) % platformSets.Count].materialSet.color = new Color(fadeInColor.r, fadeInColor.g, fadeInColor.b, fadeIn);
        }

        DisableSet(currentIndex);
        EnableSetColliders((currentIndex + 1) % platformSets.Count);

        currentIndex = (currentIndex + 1) % platformSets.Count;
    }

    void RestoreAllMaterials()
    {
        for (int i = 0; i < platformSets.Count; i++)
        {
            Color setColor = platformSets[i].materialSet.color;
            platformSets[i].materialSet.color = new Color(setColor.r, setColor.g, setColor.b, 1f);
        }
    }

    void ApplyAllMaterials()
    {
        for (int i = 0; i < platformSets.Count; i++)
        {
            for (int j = 0; j < platformSets[i].platformSet.Count; j++)
            {
                platformSets[i].platformSet[j].gameObject.GetComponent<Renderer>().material = platformSets[i].materialSet;
            }
        }
    }

    void EnableSet(int index)
    {
        for(int i = 0; i < platformSets[index].platformSet.Count; i++)
        {
            platformSets[index].platformSet[i].gameObject.SetActive(true);  
        }

       //Color setColor = platformSets[index].materialSet.color;
       //platformSets[index].materialSet.color = new Color(setColor.r, setColor.g, setColor.b, 1f);
    }

    void DisableSetColliders(int index)
    {
        for (int i = 0; i < platformSets[index].platformSet.Count; i++)
        {
            platformSets[index].platformSet[i].gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    void EnableSetColliders(int index)
    {
        for (int i = 0; i < platformSets[index].platformSet.Count; i++)
        {
            platformSets[index].platformSet[i].gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < platformSets.Count; i++)
        {
            Gizmos.color = platformSets[i].materialSet.color;

            for (int j = 0; j < platformSets[i].platformSet.Count; j++)
            {
                Gizmos.DrawWireSphere(platformSets[i].platformSet[j].transform.position, 5f);
            }
        }
    }
}
