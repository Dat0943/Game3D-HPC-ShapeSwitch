using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	Vector3 startPosition;
	Vector3 endPosition;

	float elapsedTime, elapsedTime1;
	float desiredDuration = 3f;

	void Start()
	{
		startPosition = transform.position;
		endPosition = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
	}

	void Update()
	{
		if (SpawnManager.instance.spawnType == 1)
		{
			elapsedTime += Time.deltaTime;
			float percent = elapsedTime / desiredDuration;
			transform.position = Vector3.Lerp(startPosition, endPosition, percent);
		}
		else if (SpawnManager.instance.spawnType == 2)
		{
			elapsedTime1 += Time.deltaTime;
			float percent1 = elapsedTime1 / desiredDuration;
			transform.position = Vector3.Lerp(endPosition, startPosition, percent1);
		}
	}
}
