using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {
    public float posX = 0;
    public float posZ = 0;
    public Vector3 position;
    public Transform m_transform;
    public Transform snake;

    void Start()
    {
        m_transform = this.transform;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("Snake") == 0)
        {
            Vector3 position = this.m_transform.position;
            GameObject snakeT = Instantiate(snake.transform, position, Quaternion.identity);
            snakeT.directionToMove = SnakeBody.Instance.snakeBody[0].directionToMove;
            SnakeBody.Instance.AddBody(snakeT);
            Destroy(this.gameObject);
        }
    }

    public void CreateFood()
    {
        this.FindPlace();
        this.position = new Vector3(this.posX, 0, this.posZ);
        Instantiate(m_transform, this.position, Quaternion.identity);
    }

    public void FindPlace()
    {
        float posX = 0;
        float posZ = 0;
        do { posX = (float)Random.Range(-3, 3); }
        while (SnakeBody.Instance.bodyX.Contains(posX));
        {
            posX=(float)Random.Range(-3,3);
        }

        do { posZ = (float)Random.Range(-3, 3); } 
        while (SnakeBody.Instance.bodyZ.Contains(posZ));
        {
            posZ = (float)Random.Range(-3, 3);
        }

        this.posX = posX;
        this.posZ = posZ;
    }
}
