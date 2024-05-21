using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePS;

    MeshFilter playerMeshFilter;

	private void Awake()
	{
		playerMeshFilter = GetComponent<MeshFilter>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag(Tag.CUBE_TAG) || other.CompareTag(Tag.PRIMS_TAG) || other.CompareTag(Tag.SPHERE_TAG))
		{
			if(other.CompareTag(playerMeshFilter.mesh.name))
			{
				GameManager.instance.score++;
				GUIManager.instance.UpdateScoreText(GameManager.instance.score);

				GameObject ps = Instantiate(obstaclePS, transform.position, Quaternion.identity);
				ps.GetComponent<ParticleSystemRenderer>().mesh = other.GetComponent<MeshFilter>().mesh;
				Destroy(ps, 3f);
			}
			else
			{
				GameManager.instance.EndGame();
			}
		}
	}
}
