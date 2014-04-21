using UnityEngine;
using System.Collections;

public class Snake : MonoBehaviour {
    public Transform m_transform;
    public float posX = 0;
    public float posZ = 0;
    public int directionToMove = 0;

	// Use this for initialization
	void Start () 
    {
        m_transform = this.transform;
	}

    public void Move(int direction)
    {
        if (direction == (int)Direction.DIRECTION.UP)
        {
            m_transform.Translate(new Vector3(0, 0, 1));
        }

        if (direction == (int)Direction.DIRECTION.DOWN)
        {
            m_transform.Translate(new Vector3(0, 0, -1));
        }

        if (direction == (int)Direction.DIRECTION.LEFT)
        {
            m_transform.Translate(new Vector3(-1, 0, 0));
        }

        if (direction == (int)Direction.DIRECTION.RIGHT)
        {
            m_transform.Translate(new Vector3(+1, 0, 0));
        }
    }
}
