using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatueDialog : MonoBehaviour
{
    [Header("Dialogues")]
    [SerializeField] TextMeshProUGUI statueTextField;

    [SerializeField] TextMeshProUGUI heroTextField;
    [SerializeField] List<string> statuePhrases = new List<string>();
    [SerializeField] float delayBetweenWords;
    [SerializeField] int phraseCount = 0;
    

    [Header("Sounds")]
    [SerializeField] AudioSource statueSource;
    [SerializeField] AudioClip statueClip;

    [SerializeField] StatueAppearance statueAppearance;

    void Start()
    {
        statueSource.clip = statueClip;
        heroTextField.text = "";
    }

    void Update()
    {
        if(heroTextField.text.Length > 0)
        {
            if(Input.GetKeyUp(KeyCode.E))
            {
                phraseCount++;
                heroTextField.text = "";
                StartCoroutine(PlayNextPhrase());
            }
        }
    }

    public IEnumerator PlayNextPhrase()
    {
        statueSource.Play();

        yield return new WaitForSeconds(1f);

        statueTextField.text = ""; 

        if(phraseCount < statuePhrases.Count)
        {
            string[] words = statuePhrases[phraseCount].Split(' ');

            foreach (string word in words)
            {
                statueTextField.text += word + " ";
                yield return new WaitForSeconds(delayBetweenWords);
            }
        }

        heroTextField.text = "(Press E)";

        statueSource.Stop();

      

        if(phraseCount >= statuePhrases.Count)
        {
            statueTextField.text = "";
            heroTextField.text = "";

            yield return new WaitForSeconds(2f);
            statueAppearance.RegainPlayerControl();
        }
       
        yield return new WaitForEndOfFrame();
    }
}
