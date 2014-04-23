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
        Debug.Log(position);
        Debug.Log(this.m_transform.position);
        Transform snakeT = (Transform)Instantiate(snake.transform, position, Quaternion.identity);
        Snake snakeL = snakeT.GetComponent<Snake>();
        snakeL.directionToMove = SnakeBody.Instance.snakeBody[0].directionToMove;
        SnakeBody.Instance.AddBody(snakeL);
        //Destroy(this.gameObject); //这里的报错
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
        if ((int)(this.posX - head.transform.position.x) == 1 
            && head.directionToMove == (int)Direction.DIRECTION.RIGHT
            && (int)this.posZ == head.transform.position.z)
        {
            SnakeBody.Instance.isEat = true;
        }
        else if ((int)(this.posX - head.transform.position.x) == -1 
            && head.directionToMove == (int)Direction.DIRECTION.LEFT
            && (int)this.posZ == head.transform.position.z)
        {
            SnakeBody.Instance.isEat = true;
        }
        else if ((int)(this.posZ - head.transform.position.z) == 1 
            && head.directionToMove == (int)Direction.DIRECTION.UP
            && (int)this.posX == head.transform.position.x)
        {
            SnakeBody.Instance.isEat = true;
        }
        else if ((int)(this.posZ - head.transform.position.z) == -1 
            && head.directionToMove == (int)Direction.DIRECTION.DOWN
            && (int)this.posX == head.transform.position.x)
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
        Debug.Log(this.m_transform.position);
        //打印出来的位置和this.position的位置不一致
    }

    //得到随机位置生成food
    public void FindPlace()
    {
        int posX = 0;
        int posZ = 0;
        do { posX = Random.Range(-3, 3); }
        while (SnakeBody.Instance.bodyX.Contains(posX));
        {
            posX = Random.Range(-3,3);
        }

        do { posZ = Random.Range(-3, 3); } 
        while (SnakeBody.Instance.bodyZ.Contains(posZ));
        {
            posZ = Random.Range(-3, 3);
        }
        Debug.Log("x" + posX);
        Debug.Log("Y" + posZ);

        this.posX = (float)posX;
        this.posZ = (float)posZ;
    }

    public void Update()
    {
        this.CheckFood();
    }
}
