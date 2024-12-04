using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField] Image imagePlaceHolder;
    [SerializeField] Image nextPlaceHolder;
    [SerializeField] List<DynamicPicture> dynamicPictureList;
    void Start()
    {
        nextPlaceHolder.color = new Color(1, 1, 1, 0);
        imagePlaceHolder.sprite = dynamicPictureList[0].image;
        //nextPlaceHolder.color = new Color(0, 0, 0, 1);
        StartCoroutine(CutSceneCoroutine());
    }

    void Update()
    {

    }

    IEnumerator CutSceneCoroutine()
    {
        yield return new WaitForSeconds(dynamicPictureList[0].timer);
        for(int i = 1; i < dynamicPictureList.Count; i++)
        {

            nextPlaceHolder.sprite = dynamicPictureList[i].image;     

            float time = 0f;

            // Cross fade
            while (time < dynamicPictureList[i].transitionDuration)
            {
                time += Time.deltaTime;
                float alpha = time / dynamicPictureList[i].transitionDuration;

               imagePlaceHolder.color = new Color(1, 1, 1, 1 - alpha);
               nextPlaceHolder.color = new Color(1, 1, 1, alpha);
                //nextSpriteRenderer.color = new Color(1, 1, 1, alpha);

                yield return new WaitForEndOfFrame();
            }

            // Swap the references
            imagePlaceHolder.sprite = nextPlaceHolder.sprite;
            //imagePlaceHolder.sprite = nextSpriteRenderer.sprite;
            imagePlaceHolder.color = new Color(1, 1, 1, 1);
            nextPlaceHolder.color = new Color(1, 1, 1, 0);

            yield return new WaitForSeconds(dynamicPictureList[i].timer);
        }
    }
}

[System.Serializable]
public class DynamicPicture
{
    public Sprite image;
    public float timer;
    public float transitionDuration;
}

