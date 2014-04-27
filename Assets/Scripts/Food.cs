using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Food : MonoBehaviour {
    public int posX = 0;
    public int posZ = 0;
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
        snakeL.posX = this.posX;
        snakeL.posZ = this.posZ;
        Map.Instance.snakeMap[Map.TranslateToDic(snakeL.posX, snakeL.posZ)] = false;
        SnakeBody.Instance.AddBody(snakeL);
        DestroyImmediate(food, true);
        this.CreateFood();
    }

    //检查food和snake是否满足相撞的条件
    public void CheckFood()
    {
        Snake head = SnakeBody.Instance.snakeBody[0];
        if (this.posX - head.posX == 1 && this.posZ == head.posZ
            && SnakeBody.Instance.snakeDirection == (int)Direction.DIRECTION.RIGHT)
        {
            SnakeBody.Instance.isEat = true;
        }
        else if (head.posX - this.posX == 1 && this.posZ == head.posZ
            && SnakeBody.Instance.snakeDirection == (int)Direction.DIRECTION.LEFT)
        {
            SnakeBody.Instance.isEat = true;
        }
        else if (this.posZ - head.posZ == 1 && this.posX == head.posX
            && SnakeBody.Instance.snakeDirection == (int)Direction.DIRECTION.UP)
        {
            SnakeBody.Instance.isEat = true;
        }
        else if (head.posZ - this.posZ == 1 && this.posX == head.posX
            && SnakeBody.Instance.snakeDirection == (int)Direction.DIRECTION.DOWN)
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
        List<int> canUse = this.FindPlace();
        int nextFood = Random.Range(0, canUse.Count);
        this.posX = Map.GetPosX(canUse[nextFood]);
        this.posZ = Map.GetPosZ(canUse[nextFood]);
        //foreach (int xxx in Map.snakeMap.Keys)
        //{
        //    if (!Map.snakeMap[xxx])
        //    {
        //        Debug.Log(Map.GetPosX(xxx)+"  "+Map.GetPosZ(xxx));
        //    }
        //}
        //foreach (int yyy in Map.snakeMap.Keys)
        //{
        //    Debug.Log("check values  " + yyy);
        //}
        //Debug.Log("ACTUAL" + posX + " " + posZ);
        //Debug.Log("nextFOOD" + nextFood);
        //Debug.Log("canuse" + canUse[nextFood]);
        {
            this.position = new Vector3(Map.mapToPositionX(this.posX), 0, Map.mapToPositionZ(this.posZ));
            Transform foodT = (Transform)Instantiate(m_transform, this.position, Quaternion.identity);
            this.food = foodT.GetComponent<Food>().gameObject;
            m_transform.position = position;
        }
    }

    //得到随机位置生成food
    //public bool FindPlace()
    //{
    //    //SnakeBody.Instance.ChangePosition();
    //    int posXL = 0;
    //    int posZL = 0;
    //    do
    //    { //posXL = Random.Range(1 - Map.mapX / 2, Map.mapX / 2 + 1); }
    //        posXL = Random.Range(-2, 3);
    //        posZL = Random.Range(-2, 3);
    //    }
    //    while (SnakeBody.Instance.bodyPosition.Contains(new Vector3((float)posXL,0.0f,(float)posZL)); .Contains(posXL * 0.5f) && SnakeBody.Instance.bodyZ.Contains(posZL * 0.5f));

    //    this.posX = (float)posXL * 0.5f;
    //    this.posZ = (float)posZL * 0.5f;

    //    Debug.Log(SnakeBody.Instance.bodyX.Contains(posXL * 0.5f));
    //    Debug.Log(SnakeBody.Instance.bodyZ.Contains(posZL * 0.5f));
    //    return true;
    //}

    public List<int> FindPlace()
    {
        List<int> canUse = new List<int>();
        foreach (int key in Map.Instance.snakeMap.Keys)
        {
            if (Map.Instance.snakeMap[key])
            {
                canUse.Add(key);
            }
        }
        return canUse;
    }

    public void Update()
    {
        this.CheckFood();
    }
}
