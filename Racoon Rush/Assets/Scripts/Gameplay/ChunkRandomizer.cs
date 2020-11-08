using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkRandomizer : MonoBehaviour
{
  public GameObject candyPrefab;
	public float candyChance;

	public List<GameObject> obstaclePrefabs;
	public List<GameObject> obstacleHotspots;
	public float obstacleChance;

	public GameObject TrashPointsPrefab;
	public List<GameObject> TrashPointsHotspots;
	public float TrashPointsChance;

	static float difficultyScale = 1f;
    void Start()
    {
        difficultyScale += 0.1f;

		foreach (GameObject hotspot in obstacleHotspots)
		{
			if (Random.Range(0, 100) < Mathf.Clamp(obstacleChance * difficultyScale, 0, 90))
			{
				Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)], hotspot.transform.position, Quaternion.identity);
			}
			else if (Random.Range(0, 100) < candyChance * difficultyScale)
			{
				Instantiate(candyPrefab, hotspot.transform.position, Quaternion.identity);
			}
		}

		foreach (GameObject hotspot in TrashPointsHotspots)
		{
			if (Random.Range(0, 100) < TrashPointsChance * difficultyScale)
			{
				Instantiate(candyPrefab, hotspot.transform.position, Quaternion.identity);
				Instantiate(TrashPointsPrefab, hotspot.transform.position, Quaternion.identity);
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
