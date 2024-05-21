using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Mesh[] playerMeshs;

    Animation playerAnim;

    int tempMeshIndex = 0;

	private void Awake()
	{
		playerAnim = GetComponent<Animation>();
	}

	public void ChangePlayer()
    {
        if(tempMeshIndex + 1 < playerMeshs.Length)
        {
            tempMeshIndex++;
        }
        else
        {
            tempMeshIndex = 0;
        }

        Invoke("ApplyMesh", 0.3f);
        ChangePlayerAnim();
    }

    void ApplyMesh()
    {
		GetComponent<MeshFilter>().mesh = playerMeshs[tempMeshIndex];
	}

    void ChangePlayerAnim()
    {
        switch(tempMeshIndex)
        {
            case 0:
                playerAnim.Play("sphereToCube");
                break;
            case 1:
                playerAnim.Play("cubeToPrims");
                break;
            case 2:
                playerAnim.Play("primsToSphere");
                break;
        }
    }
}
