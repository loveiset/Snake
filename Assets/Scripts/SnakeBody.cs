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
    public AudioClip m_moveClip;
    protected AudioSource m_audio;
    
    //定义蛇头下一步将会遇见的物体，0表示正常运行，1表示将会遇见食物，2表示将会结束游戏（碰到自身，墙壁或者其它结束游戏的物体）
    public int isEat = 0;
    bool isMoved = true;

    public int headNextPosX = 0;
    public int headNextPosZ = 0;

    void Awake()
    {
        Instance = this;
    }

	void Start () 
    {
        AddBody(snake);
        m_audio = this.audio;
        //ChangePosition();
        m_food.CreateFood();
        Map.Instance.snakeMap[Map.TranslateToDic(snake.posX, snake.posZ)] = false;
        headNextPosX = snake.posX;
        headNextPosZ = snake.posZ;
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
        m_audio.PlayOneShot(m_moveClip);
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

    public void GetNextHeadPosition()
    {
        if (snakeDirection == (int)Direction.DIRECTION.UP)
        {
            this.headNextPosZ += 1;
        }
        else if (snakeDirection == (int)Direction.DIRECTION.DOWN)
        {
            this.headNextPosZ -= 1;
        }
        else if (snakeDirection == (int)Direction.DIRECTION.LEFT)
        {
            this.headNextPosX -= 1;
        }
        else if (snakeDirection == (int)Direction.DIRECTION.RIGHT)
        {
            this.headNextPosX += 1;
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

    void CheckPosition()
    {
        if (headNextPosX < 0 || headNextPosX >= Map.mapX || headNextPosZ < 0 || headNextPosZ >= Map.mapZ)
        {
            isEat = 2;
        }
    }
	
    void Update()
    {
        m_moveRate -= Time.deltaTime;
        this.GetDirection();

        if (m_moveRate <= 0)
        {
            m_moveRate = 0.12f;
            GetNextHeadPosition();
            CheckPosition();
            if (isEat == 2)
            {
                GameManager.Instance.isDead = true;
                return;
            }
            m_food.CheckFood();
            if (isEat==1)
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
