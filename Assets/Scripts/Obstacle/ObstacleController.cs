using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
	[SerializeField] private float moveSpeed;

	Vector3 nextPos;

	void Update()
	{
		ObstacleMovement();
	}

	void ObstacleMovement()
	{
		nextPos = transform.position;
		nextPos.z -= moveSpeed * Time.deltaTime;
		transform.position = nextPos;
	}
}
