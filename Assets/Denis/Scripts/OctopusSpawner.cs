using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusSpawner : MonoBehaviour
{

	public GameObject fruitPrefab;
	public Transform[] spawnPoints;

	public float minDelay = .05f;
	public float maxDelay = .7f;

	private float spawnTime;
	// Use this for initialization
	void Start()
	{
	}

    private void Update()
    {
		if (spawnTime >= 0)
		{
			spawnTime -= Time.deltaTime;
		}
	}

    public void SpawnOctopus(float spawnTime_)
    {
		spawnTime = spawnTime_;
		StartCoroutine(SpawnFruits());
	}

	IEnumerator SpawnFruits()
	{
		while (spawnTime > 0 )
		{
			float delay = Random.Range(minDelay, maxDelay);
			yield return new WaitForSeconds(delay);

			int spawnIndex = Random.Range(0, spawnPoints.Length);
			Transform spawnPoint = spawnPoints[spawnIndex];

			GameObject spawnedFruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
			Destroy(spawnedFruit, 5f);
		}
	}

}
