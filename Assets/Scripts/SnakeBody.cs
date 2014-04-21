using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;

public class SnakeBody : MonoBehaviour {
    public List<Snake> snakeBody;
    public Snake food;
    public Snake food2;
    public int snakeDirection = 0;
    public float moveRate = 1;


	// Use this for initialization
	void Start () 
    {
        AddBody(food);
	}

    public void AddBody(Snake food)
    {
        this.snakeBody.Insert(0, food);
    }

    public void Move(int direction)
    {
        int direct = direction;
        foreach (Snake snake in snakeBody)
        {
            snake.Move(direct);
            direct = snake.directionToMove;
        }
    }
	
	// Update is called once per frame
	void Update () 
    {
        moveRate -= Time.deltaTime;
        if (moveRate <= 0)
        {
            moveRate = 0.1f;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (snakeDirection == (int)Direction.DIRECTION.UP)
                {
                    return;
                }
                this.snakeDirection = (int)Direction.DIRECTION.UP;
                Move(snakeDirection);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (snakeDirection == (int)Direction.DIRECTION.DOWN)
                {
                    return;
                }
                this.snakeDirection = (int)Direction.DIRECTION.DOWN;
                Move(snakeDirection);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (snakeDirection == (int)Direction.DIRECTION.LEFT)
                {
                    return;
                }
                this.snakeDirection = (int)Direction.DIRECTION.LEFT;
                Move(snakeDirection);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (snakeDirection == (int)Direction.DIRECTION.RIGHT)
                {
                    return;
                }
                this.snakeDirection = (int)Direction.DIRECTION.RIGHT;
                Move(snakeDirection);
            }

            //Move(snakeDirection);
        }
	
	}
}
