using UnityEngine;
using System.Collections;

public class Snake : MonoBehaviour {
    public Transform m_transform;
    int _directionToMove;

    public int directionToMove
    {
        get
        {
            return this._directionToMove;
        }
        set
        {
            this._directionToMove = value;
        }
    }

    public const float snakeSize = 0.5f;

    public int posX = 0;
    public int posZ = 0;

	void Start () 
    {
        m_transform = this.transform;
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("Food") != 0)
        {
            if (!GameManager.Instance.isDead)
            {
                GameManager.Instance.isDead = true;
            }
        }
    }

    //移动单个snake
    public void Move()
    {
        Map.Instance.snakeMap[Map.TranslateToDic(this.posX, this.posZ)] = true;
        if (directionToMove == (int)Direction.DIRECTION.UP)
        {
            m_transform.Translate(new Vector3(0, 0, snakeSize));
            this.posZ += 1;
        }

        if (directionToMove == (int)Direction.DIRECTION.DOWN)
        {
            m_transform.Translate(new Vector3(0, 0, -snakeSize));
            this.posZ -= 1;
        }

        if (directionToMove == (int)Direction.DIRECTION.LEFT)
        {
            m_transform.Translate(new Vector3(-snakeSize, 0, 0));
            this.posX -= 1;
            
        }

        if (directionToMove == (int)Direction.DIRECTION.RIGHT)
        {
            m_transform.Translate(new Vector3(+snakeSize, 0, 0));
            this.posX += 1;
        }
        Map.Instance.snakeMap[Map.TranslateToDic(posX, posZ)] = false;
    }
}
