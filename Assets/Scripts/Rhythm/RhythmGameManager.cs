using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmGameManager : MonoBehaviour
{
    public AudioSource gameMusic;

    public bool startPlaying;

    public BeatScroller beatScroller;

    public static RhythmGameManager instance;

    public int rhythmGameScore = 7;
    public int scorePerNote = 1;
    public bool isActive = false;
    public float musicDuration = 53.88f;
    public int winCond = 1;
    public GameObject buttons;
    public GameObject backgroundMusicManager;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (!startPlaying)
            {
                startPlaying = true;
                beatScroller.hasStarted = true;

                gameMusic.Play();
                StartCoroutine(MeasureMusicLength(musicDuration));
            }

            if (rhythmGameScore <= 0)
            {
                FindObjectOfType<CardScript>().StartFightF();
                startPlaying = false;
                gameMusic.Stop();
                winCond = 0;
                isActive = false;
                buttons.SetActive(false);
                backgroundMusicManager.GetComponent<AudioSource>().mute = false;
                if (GameObject.FindGameObjectWithTag("Player") != null)
                {
                    player = GameObject.FindGameObjectWithTag("Player");
                    player.GetComponent<Health>().Heal(20f);
                }
            }

            if (winCond == 2)
            {
                FindObjectOfType<CardScript>().StartFightF();
                isActive = false;
                buttons.SetActive(false);
                backgroundMusicManager.GetComponent<AudioSource>().mute = false;
                if (GameObject.FindGameObjectWithTag("Player") != null)
                {
                    player = GameObject.FindGameObjectWithTag("Player");
                    player.GetComponent<Health>().Heal(100f);
                }
            }
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

    IEnumerator MeasureMusicLength(float duration)
    {
        yield return new WaitForSeconds(duration);
        winCond = 2;
    }
}
