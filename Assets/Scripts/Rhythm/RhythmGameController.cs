using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmGameController : MonoBehaviour
{
    public GameObject buttons;
    public GameObject backgroundMusicManager;
    public GameObject noteHolder;
    // Start is called before the first frame update
    void Start()
    {
        backgroundMusicManager = GameObject.Find("BackgroundMusicManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRhythmGame()
    {

        buttons.SetActive(true);
        backgroundMusicManager.GetComponent<AudioSource>().mute = true;
        RhythmGameManager.instance.GetComponent<RhythmGameManager>().isActive = true;
        noteHolder.GetComponent<ArrowSpawn>().nextSpawnTime = Time.time;
    }
}
