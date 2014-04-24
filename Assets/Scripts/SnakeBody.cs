using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeBody : MonoBehaviour {
    public Food m_food;
    public static SnakeBody Instance;
    public List<Snake> snakeBody;
    public List<float> bodyX;
    public List<float> bodyZ;
    public Snake snake;
    public int snakeDirection = 0;
    float m_moveRate = 0;
    //float m_dirRate = 0;
    public bool isEat = false;
    public const float snakeSize = 0.5f;

    void Awake()
    {
        Instance = this;
    }

	void Start () 
    {
        m_food.CreateFood();
        AddBody(snake);
	}

    //不用管这个
    public void AddBody(Snake snake)
    {
        this.snakeBody.Insert(0, snake);
    }

    //刷新snake的位置，防止food出现在snake的位置
    public void ChangePosition()
    {
        bodyX.Clear();
        bodyZ.Clear();
        for (int i = 0; i < snakeBody.Count; i++)
        {
            bodyX.Add(snakeBody[i].posX);
            bodyZ.Add(snakeBody[i].posZ);
        }
    }
    

    //移动所有的snake,循环调用snake的调用函数
    public void Move(int direction)
    {
        int direct = direction;
        int directBack=0;
        for(int i=0;i<snakeBody.Count;i++)
        {
            directBack = snakeBody[i].directionToMove;
            snakeBody[i].SetDirection(direct);
            snakeBody[i].Move();
            direct = directBack;
        }
    }

    //检查方向键，得到下一步要移动的方向
    public void GetDirection()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (snakeDirection == (int)Direction.DIRECTION.DOWN)
            {
                return;
            }
            this.snakeDirection = (int)Direction.DIRECTION.UP;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (snakeDirection == (int)Direction.DIRECTION.UP)
            {
                return;
            }
            this.snakeDirection = (int)Direction.DIRECTION.DOWN;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (snakeDirection == (int)Direction.DIRECTION.RIGHT)
            {
                return;
            }
            this.snakeDirection = (int)Direction.DIRECTION.LEFT;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (snakeDirection == (int)Direction.DIRECTION.LEFT)
            {
                return;
            }
            this.snakeDirection = (int)Direction.DIRECTION.RIGHT;
        }
    }
	
    void Update()
    {
        m_moveRate -= Time.deltaTime;
        this.GetDirection();

        if (m_moveRate <= 0)
        {
            m_moveRate = 0.15f;
            m_food.CheckFood();
            if (this.isEat)
            {
                m_food.AddSnake();
                this.GetDirection();
            }
            else
            {
                this.Move(snakeDirection);
            }
        }
    }
}
