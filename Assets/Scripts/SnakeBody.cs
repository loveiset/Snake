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

    void Awake()
    {
        Instance = this;
    }
	// Use this for initialization

	void Start () 
    {
        m_food.CreateFood();
        AddBody(snake);
	}

    public void AddBody(Snake snake)
    {
        Debug.Log("eat");
        this.snakeBody.Insert(0, snake);
    }

    public void AddSnake()
    {
        Vector3 position = m_food.transform.position;
        Transform snakeT = (Transform)Instantiate(snake.transform, position, Quaternion.identity);
        Snake snakeL = snakeT.gameObject.GetComponent<Snake>();
        AddBody(snakeL);
    }

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
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (snakeDirection == (int)Direction.DIRECTION.DOWN)
            {
                return;
            }
            this.snakeDirection = (int)Direction.DIRECTION.UP;
            Move(snakeDirection);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (snakeDirection == (int)Direction.DIRECTION.UP)
            {
                return;
            }
            this.snakeDirection = (int)Direction.DIRECTION.DOWN;
            Move(snakeDirection);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (snakeDirection == (int)Direction.DIRECTION.RIGHT)
            {
                return;
            }
            this.snakeDirection = (int)Direction.DIRECTION.LEFT;
            Move(snakeDirection);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (snakeDirection == (int)Direction.DIRECTION.LEFT)
            {
                return;
            }
            this.snakeDirection = (int)Direction.DIRECTION.RIGHT;
            Move(snakeDirection);
        }

        //Move(snakeDirection);


    }
}
