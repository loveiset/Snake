using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Food : MonoBehaviour {
    public float posX = 0.0f;
    public float posZ = 0.0f;
    public Vector3 position;
    public Transform m_transform;
    public Transform snake;
    GameObject food;

    void Start()
    {
        m_transform = this.transform;
    }

    //在当前food位置生成一个新的snake
    public void AddSnake()
    {
        position = this.m_transform.position;
        Transform snakeT = (Transform)Instantiate(snake.transform, position, Quaternion.identity);
        Snake snakeL = snakeT.GetComponent<Snake>();
        snakeL.directionToMove = SnakeBody.Instance.snakeDirection;
        snakeL.posX = position.x;
        snakeL.posZ = position.z;
        SnakeBody.Instance.AddBody(snakeL);
        DestroyImmediate(food, true);
        this.CreateFood();
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag.CompareTo("Snake") == 0)
    //    {
    //        Destroy(this.gameObject);
    //        this.CreateFood();
    //    }
    //}

    //检查food和snake是否满足相撞的条件
    public void CheckFood()
    {
        Snake head = SnakeBody.Instance.snakeBody[0];
        if (this.posX - head.transform.position.x == Snake.snakeSize
            && SnakeBody.Instance.snakeDirection == (int)Direction.DIRECTION.RIGHT
            && this.posZ == head.transform.position.z)
        {
            SnakeBody.Instance.isEat = true;
        }
        else if (head.transform.position.x - this.posX == Snake.snakeSize
            && SnakeBody.Instance.snakeDirection == (int)Direction.DIRECTION.LEFT
            && this.posZ == head.transform.position.z)
        {
            SnakeBody.Instance.isEat = true;
        }
        else if (this.posZ - head.transform.position.z == Snake.snakeSize
            && SnakeBody.Instance.snakeDirection == (int)Direction.DIRECTION.UP
            && this.posX == head.transform.position.x)
        {
            SnakeBody.Instance.isEat = true;
        }
        else if (head.transform.position.z - this.posZ  == Snake.snakeSize
            && SnakeBody.Instance.snakeDirection == (int)Direction.DIRECTION.DOWN
            && this.posX == head.transform.position.x)
        {
            SnakeBody.Instance.isEat = true;
        }
        else
        {
            SnakeBody.Instance.isEat = false;
        }
    }

    //创建food
    public void CreateFood()
    {
        if (this.FindPlace())
        {
            this.position = new Vector3(this.posX, 0, this.posZ);
            Transform foodT = (Transform)Instantiate(m_transform, this.position, Quaternion.identity);
            this.food = foodT.GetComponent<Food>().gameObject;
            m_transform.position = position;
            for (int i = 0; i < SnakeBody.Instance.bodyX.Count; i++)
            {
                Debug.Log(SnakeBody.Instance.bodyX[i] + " " + SnakeBody.Instance.bodyZ[i]);
            }
            Debug.Log(position);
        }
    }

    //得到随机位置生成food
    public bool FindPlace()
    {
        SnakeBody.Instance.ChangePosition();
        int posXL = 0;
        int posZL = 0;
        do
        { //posXL = Random.Range(1 - Map.mapX / 2, Map.mapX / 2 + 1); }
            posXL = Random.Range(-2, 3);
            posZL = Random.Range(-2, 3);
        }
        while (SnakeBody.Instance.bodyPosition.Contains(new Vector3((float)posXL,0.0f,(float)posZL)); .Contains(posXL * 0.5f) && SnakeBody.Instance.bodyZ.Contains(posZL * 0.5f));

        this.posX = (float)posXL * 0.5f;
        this.posZ = (float)posZL * 0.5f;

        Debug.Log(SnakeBody.Instance.bodyX.Contains(posXL * 0.5f));
        Debug.Log(SnakeBody.Instance.bodyZ.Contains(posZL * 0.5f));
        return true;
    }

    public void Update()
    {
        this.CheckFood();
    }
}
