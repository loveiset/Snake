using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
    GameObject wall;

    public Transform m_transform;

    float left = Snake.snakeSize / 2 - Map.mapSizeX / 2;
    float top = Map.mapSizeZ / 2 + Snake.snakeSize / 2;
    float buttom = Snake.snakeSize / 2 - Map.mapSizeZ / 2;
    float right = Snake.snakeSize / 2 + Map.mapSizeX / 2;

    public void CreateSingleWall(float x, float z)
    {
        Transform wallT = (Transform)Instantiate(this.m_transform, new Vector3(x, 0, z), Quaternion.identity);
        this.wall = wallT.GetComponent<Wall>().gameObject;
        //this.wall.SetActive(false);
    }

    public void CreateWall()
    {
        for (int i = 0; i < Map.mapSizeZ / Snake.snakeSize; i++)
        {
            CreateSingleWall(left - Snake.snakeSize / 2, top - Snake.snakeSize / 2 - i * Snake.snakeSize);
            CreateSingleWall(right + Snake.snakeSize / 2, top - Snake.snakeSize / 2 - i * Snake.snakeSize);
        }

        for (int i = 0; i < Map.mapSizeZ / Snake.snakeSize; i++)
        {
            CreateSingleWall(left + Snake.snakeSize / 2 + i * Snake.snakeSize, top + Snake.snakeSize / 2);
            CreateSingleWall(left + Snake.snakeSize / 2 + i * Snake.snakeSize, buttom - Snake.snakeSize / 2);
        }
    }

	void Start () 
    {
        m_transform = this.transform;
        //CreateSingleWall(4.0f, 3.0f);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("Snake")==0)
        {
            Debug.Log("die wall");
        }
    }
}
