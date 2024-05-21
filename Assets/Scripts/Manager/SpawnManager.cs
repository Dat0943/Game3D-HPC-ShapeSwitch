using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public static SpawnManager instance;

    [SerializeField] private GameObject[] obstacles, buttonPanel, players, grounds;
    [SerializeField] private float timeBetweenSpawns;

	Vector3 spawnPos;
	bool spawnChanged = false;

	public int spawnType = 0;

	private void Awake()
	{
		if(instance == null)
			instance = this;
	}

	void Start()
	{
		spawnPos = transform.position;
		buttonPanel[0].SetActive(true);
	}

	public void Spawn()
	{
		switch (spawnType)
		{
			case 0: 
				Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPos, Quaternion.identity);
				break;
			case 1:
				if (!spawnChanged)
				{
					spawnChanged = true;
					ActivePlayer();
					PanelSwitch();
				}
				else
				{
					spawnPos = transform.position;
					Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPos, Quaternion.identity);
					spawnPos.x = 3f;
					Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPos, Quaternion.identity);
				}
				break;
			case 2:
				if (!spawnChanged)
				{
					spawnChanged = true;

				}
				else
				{
					ActivePlayer();
					PanelSwitch();

					spawnPos = transform.position;
					Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPos, Quaternion.identity);
					spawnPos.x = 3f;
					Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPos, Quaternion.identity);
					spawnPos.x = -3f;
					Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPos, Quaternion.identity);
				}
				break;
		}

		Invoke("Spawn", timeBetweenSpawns); // Thời gian giữa những lần đổi
		ChangeSpawnType();
	}



	void ChangeSpawnType()
	{
		if (GameManager.instance.score < 4)
		{
			spawnType = 0;
		}
		else if (GameManager.instance.score >= 4 && GameManager.instance.score < 12)
		{
			spawnType = 1;
		}
		else
		{
			spawnType = 2;
		}
	}

	void PanelSwitch()
	{
		if (spawnType == 1)
		{
			buttonPanel[0].SetActive(false);
			buttonPanel[1].SetActive(true);
		}
		else if (spawnType == 2)
		{
			buttonPanel[0].SetActive(false);
			buttonPanel[1].SetActive(false);
			buttonPanel[2].SetActive(true);
		}
	}

	void ActivePlayer()
	{
		if (spawnType == 1)
		{
			players[1].SetActive(true);
			grounds[1].SetActive(true);
		}
		else if (spawnType == 2)
		{
			players[2].SetActive(true);
			grounds[2].SetActive(true);
		}
	}
}
