
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCleanup : MonoBehaviour
{
	private void Start()
	{
		StartCoroutine(CleanUp());
	}

	IEnumerator CleanUp()
	{
		yield return new WaitForSeconds(10);
		Destroy(this.gameObject);
	}
}