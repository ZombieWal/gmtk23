using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmGameManager : MonoBehaviour
{
    public AudioSource gameMusic;

    public bool startPlaying;

    public BeatScroller beatScroller;

    public static RhythmGameManager instance;

    public int rhythmGameScore = 2;
    public int scorePerNote = 1;
    public int rhythmGameWin = 1;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                beatScroller.hasStarted = true;

                gameMusic.Play();
            }
        }

        if(rhythmGameScore <= 0)
        {
            startPlaying = false;
            gameMusic.Stop();
            rhythmGameWin = 0;
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit on time!");
    }

    public void NoteMissed()
    {
        Debug.Log("Missed!");
        rhythmGameScore -= scorePerNote;
        Debug.Log("score " + rhythmGameScore);
    }
}
