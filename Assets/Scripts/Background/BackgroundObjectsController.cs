using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundObjectsController : MonoBehaviour
{
    Vector3 nextPos;

    float moveSpeed;
    float invokeTime;

    bool upMove = false;

	void Start()
	{
		moveSpeed = Random.Range(0.5f, 5f);
		invokeTime = Random.Range(2f, 10f);

		if (Random.Range(0, 2) == 0)
			upMove = true;

		Invoke("ChangeDirection", invokeTime);
	}

	void Update()
	{
		ObjectMovement();
	}

	void ObjectMovement()
	{
		nextPos = transform.position;

		if (upMove)
		{
			nextPos.y += moveSpeed * Time.deltaTime;
		}
		else
		{
			nextPos.y -= moveSpeed * Time.deltaTime;
		}

		transform.position = nextPos;
	}

	void ChangeDirection()
	{
		moveSpeed = Random.Range(0.5f, 5f);
		invokeTime = Random.Range(2f, 10f);

		upMove = !upMove;

		Invoke("ChangeDirection", invokeTime);
	}
}
