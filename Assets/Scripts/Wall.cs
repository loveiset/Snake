using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
    GameObject wall;
    public Transform m_transform;

    float left = 0.0f;
    float top = Map.mapSizeZ;
    float buttom = 0.0f;
    float right = Map.mapSizeX;

    public void CreateSingleWall(float x, float z)
    {
        Transform wallT = (Transform)Instantiate(this.m_transform, new Vector3(x, 0, z), Quaternion.identity);
        this.wall = wallT.GetComponent<Wall>().gameObject;
    }

    public void CreateWall()
    {
        for (int i = 0; i < Map.mapX; i++)
        {
            CreateSingleWall(Snake.snakeSize / 2 + i * Snake.snakeSize, top + Snake.snakeSize / 2);
            CreateSingleWall(i * Snake.snakeSize + Snake.snakeSize / 2, buttom - Snake.snakeSize / 2);
        }

        for (int i = 0; i < Map.mapZ; i++)
        {
            CreateSingleWall(left - Snake.snakeSize / 2, Snake.snakeSize / 2 + i * Snake.snakeSize);
            CreateSingleWall(right + Snake.snakeSize / 2, i * Snake.snakeSize + Snake.snakeSize / 2);
        }
    }

	void Start () 
    {
        m_transform = this.transform;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("Snake")==0)
        {
            if (!GameManager.Instance.isDead)
            {
                GameManager.Instance.isDead = true;
            }
        }
    }
}
