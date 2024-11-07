using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSource : MonoBehaviour
{
    [SerializeField] AudioSource noteSource;
    [SerializeField] List<AudioClip> notes;

    private List<int> noteOrder = new List<int>();
    bool playing = false;
    void Start()
    {
        RefreshPuzzle();
        
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!playing)
            {
                StartCoroutine(PlayNotes());
            }
        }
    }

    private void RefreshPuzzle()
    {
        noteOrder.Clear();

        //noteOrder = new List<int>(notes.Count);

        for(int i = 0; i < notes.Count; i++)
        {
            noteOrder.Add(i);
        }

        for (int i = noteOrder.Count - 1; i > 0; i--) 
        { 
            int randomIndex = Random.Range(0, i + 1); 
            int temp = noteOrder[i]; 
            noteOrder[i] = noteOrder[randomIndex]; 
            noteOrder[randomIndex] = temp; 
        }
        
    }

    public IEnumerator PlayNotes()
    {
        playing = true;

        for (int i = 0; i < noteOrder.Count; i++)
        {
            noteSource.clip = notes[i];

            noteSource.Play();

            yield return new WaitForSeconds(noteSource.clip.length * 0.5f + 0.1f);
        }

        playing = false;
    }
}
