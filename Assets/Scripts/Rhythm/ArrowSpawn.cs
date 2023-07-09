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

    public Transform[] arrowSpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time;
        spawnInterval = 132.0f / 60.0f;

    }

    // Update is called once per frame
    void Update()
    {
        score = RhythmGameManager.instance.rhythmGameScore;

        if ( score> 0)
        {
            if (Time.time > nextSpawnTime)
            {
                SpawnArrow();
                nextSpawnTime += spawnInterval;
            }
        }
    }

    void SpawnArrow()
    {
        GameObject arrowToSpawn;
        Transform spawnPoint;

        // Select a different arrow for each beat
        switch (Random.Range(1, 5))
        {
            case 1:
                arrowToSpawn = arrowUp;
                spawnPoint = arrowSpawnPoints[1];
                break;
            case 2:
                arrowToSpawn = arrowDown;
                spawnPoint = arrowSpawnPoints[2];
                break;
            case 3:
                arrowToSpawn = arrowLeft;
                spawnPoint = arrowSpawnPoints[0];
                break;
            case 4:
                arrowToSpawn = arrowRight;
                spawnPoint = arrowSpawnPoints[3];
                break;
            default:
                arrowToSpawn = arrowUp;
                spawnPoint = arrowSpawnPoints[1];
                break;
        }

        GameObject arrow = Instantiate(arrowToSpawn, spawnPoint.position, Quaternion.identity);
        arrow.transform.SetParent(noteHolder, false);

    }
}