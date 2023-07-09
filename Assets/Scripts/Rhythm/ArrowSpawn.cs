using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    public GameObject arrowUp;
    public GameObject arrowDown;
    public GameObject arrowLeft;
    public GameObject arrowRight;
    public Transform noteHolder;

    private float spawnInterval; // Time between each spawn
    private float nextSpawnTime; // Time when the next spawn will occur
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time;
        spawnInterval = 132.0f / 60.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (RhythmGameManager.instance.isActive && RhythmGameManager.instance.winCond == 1)
        {
            score = RhythmGameManager.instance.rhythmGameScore;
            if (score > 0)
            {
                if (Time.time > nextSpawnTime)
                {
                    SpawnArrow();
                    nextSpawnTime += spawnInterval;
                }
            }
        }
    }

    void SpawnArrow()
    {
        GameObject arrowToSpawn;
        Vector3 spawnPoint;

        // Select a different arrow for each beat
        switch (Random.Range(1, 5))
        {
            case 1:
                arrowToSpawn = arrowUp;
                spawnPoint = new Vector3(1f, -0.56f, 0.0f);
                break;
            case 2:
                arrowToSpawn = arrowDown;
                spawnPoint = new Vector3(1f, -1.7f, 0.0f);
                break;
            case 3:
                arrowToSpawn = arrowLeft;
                spawnPoint = new Vector3(1f, 0.5f, 0.0f);
                break;
            case 4:
                arrowToSpawn = arrowRight;
                spawnPoint = new Vector3(1f, -2.6f, 0.0f);
                break;
            default:
                arrowToSpawn = arrowUp;
                spawnPoint = new Vector3(1f, -0.56f, 0.0f);
                break;
        }

        GameObject arrow = Instantiate(arrowToSpawn, spawnPoint, Quaternion.identity);
        arrow.transform.SetParent(noteHolder, true);

    }
}