using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
	[SerializeField] private GameObject chunkPrefab;
	public GameObject gameChunkParent;

	void Start()
    {

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
		Vector3 spawnLocation =  gameChunkParent.transform.position + new Vector3(21.6f, 0, 0);
		var newChunk = Instantiate(chunkPrefab, spawnLocation, Quaternion.identity);
		newChunk.name = "GameChunk";
		}
	}
}
