using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeBody : MonoBehaviour {
    public Food m_food;
    public static SnakeBody Instance;
    public List<Snake> snakeBody;
    public Snake snake;
    public int snakeDirection = 0;
    float m_moveRate = 0;
    public bool isEat = false;
    bool isMoved = true;

    void Awake()
    {
        Instance = this;
    }

	void Start () 
    {
        AddBody(snake);
        //ChangePosition();
        m_food.CreateFood();
	}

    //不用管这个
    public void AddBody(Snake snake)
    {
        this.snakeBody.Insert(0, snake);
    }

    //刷新snake的位置，防止food出现在snake的位置
    //public void ChangePosition()
    //{
    //    bodyPosition.Clear();
    //    for (int i = 0; i < snakeBody.Count; i++)
    //    {
    //        bodyPosition.Add(new float[]=);
    //    }
    //    Debug.Log("haha" + bodyPosition[0].position);
    //}
    

    //移动所有的snake,循环调用snake的调用函数
    public void Move(int direction)
    {
        int direct = direction;
        int directBack=0;
        for(int i=0;i<snakeBody.Count;i++)
        {
            directBack = snakeBody[i].directionToMove;
            snakeBody[i].directionToMove = direct;
            snakeBody[i].Move();
            direct = directBack;
        }
    }

    //检查方向键，得到下一步要移动的方向
    public void GetDirection()
    {
        if (isMoved)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                if (snakeDirection == (int)Direction.DIRECTION.DOWN)
                {
                    return;
                }
                this.snakeDirection = (int)Direction.DIRECTION.UP;
                isMoved = false;
            }

            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                if (snakeDirection == (int)Direction.DIRECTION.UP)
                {
                    return;
                }
                this.snakeDirection = (int)Direction.DIRECTION.DOWN;
                isMoved = false;
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                if (snakeDirection == (int)Direction.DIRECTION.RIGHT)
                {
                    return;
                }
                this.snakeDirection = (int)Direction.DIRECTION.LEFT;
                isMoved = false;
            }

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                if (snakeDirection == (int)Direction.DIRECTION.LEFT)
                {
                    return;
                }
                this.snakeDirection = (int)Direction.DIRECTION.RIGHT;
                isMoved = false;
            }
        }
        else
        {
            return;
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
                isMoved = true;
            }
        }
    }
}
