using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {
    public float posX = 0;
    public float posZ = 0;
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
        Vector3 position = this.m_transform.position;
        Debug.Log(this.m_transform.position);
        Transform snakeT = (Transform)Instantiate(snake.transform, position, Quaternion.identity);
        Snake snakeL = snakeT.GetComponent<Snake>();
        snakeL.directionToMove = SnakeBody.Instance.snakeDirection;
        snakeL.posX = position.x;
        snakeL.posZ = position.z;
        SnakeBody.Instance.AddBody(snakeL);
        DestroyImmediate(food, true);
        Debug.Log("here");
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
        this.FindPlace();
        this.position = new Vector3(this.posX, 0, this.posZ);
        Transform foodT = (Transform)Instantiate(m_transform, this.position, Quaternion.identity);
        this.food = foodT.GetComponent<Food>().gameObject;
        m_transform.position = position;
    }

    //得到随机位置生成food
    public void FindPlace()
    {
        //SnakeBody.Instance.ChangePosition();
        int posXL = 0;
        int posZL = 0;
        do { posXL = Random.Range(-1, 1); }
        while (SnakeBody.Instance.bodyX.Contains(posXL));
        {
            posXL = Random.Range(-1, 1);
        }

        do { posZL = Random.Range(-1, 1); } 
        while (SnakeBody.Instance.bodyZ.Contains(posZL));
        {
            posZL = Random.Range(-1, 1);
        }

        this.posX = posXL * 0.5f;
        this.posZ = posZL * 0.5f;
    }

    public void Update()
    {
        this.CheckFood();
    }
}
