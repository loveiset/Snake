using UnityEngine;
using System.Collections;

public class Snake : MonoBehaviour {
    public Transform m_transform;
    
    public float posX = 0.0f;
    public float posZ = 0.0f;
    
    public int directionToMove = 0;

    public const float snakeSize = 0.5f;

	void Start () 
    {
        m_transform = this.transform;
	}

    public void SetDirection(int direction)
    {
        this.directionToMove = direction;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("Food") != 0)
        {
            Debug.Log("die");
        }
    }

    //移动单个snake
    public void Move()
    {
        if (directionToMove == (int)Direction.DIRECTION.UP)
        {
            m_transform.Translate(new Vector3(0, 0, snakeSize));
            this.posZ += snakeSize;
        }

        if (directionToMove == (int)Direction.DIRECTION.DOWN)
        {
            m_transform.Translate(new Vector3(0, 0, -snakeSize));
            this.posZ -= snakeSize;
        }

        if (directionToMove == (int)Direction.DIRECTION.LEFT)
        {
            m_transform.Translate(new Vector3(-snakeSize, 0, 0));
            this.posX -= snakeSize;
        }

        if (directionToMove == (int)Direction.DIRECTION.RIGHT)
        {
            m_transform.Translate(new Vector3(+snakeSize, 0, 0));
            this.posX += snakeSize;
        }
    }
}
