using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
	[SerializeField] private GameObject chunkPrefab;
	public GameObject gameChunkParent;

	public float offset = 0;

	public Transform lastPosition;

	void Start()
    {
       lastPosition = gameChunkParent.transform;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
		Vector3 spawnLocation =  new Vector3(lastPosition.position.x + offset, -0.188f, 0);
		var newChunk = Instantiate(chunkPrefab, spawnLocation, Quaternion.identity);
		newChunk.name = "GameChunk";
		lastPosition = newChunk.transform;
		
		
		}
	}
}
