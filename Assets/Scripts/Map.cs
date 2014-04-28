using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour {
    //地图都从0开始
    public static Map Instance;
    //public Wall m_wall;
    public const int mapX = 16;
    public const int mapZ = 16;
    public static float mapSizeX = mapX * Snake.snakeSize;
    public static float mapSizeZ = mapZ * Snake.snakeSize;

    //用键值对来表示地图每个块的状态
    public Dictionary<int, bool> snakeMap = new Dictionary<int, bool>();

    //初始化地图状态
    void InitMap()
    {
        for (int i = 0; i < mapX; i++)
        {
            for (int j = 0; j < mapZ; j++)
            {
                snakeMap.Add(i + mapZ * j, true);
            }
        }
    }

    public static int TranslateToDic(int x, int z)
    {
        return x + mapX * z;
    }

    public static int GetPosX(int position)
    {
        return position % mapX;
    }

    public static int GetPosZ(int position)
    {
        return position / mapX;
    }

    public static float mapToPositionX(int mapGridX)
    {
        return Snake.snakeSize / 2 + mapGridX * Snake.snakeSize;
    }

    public static float mapToPositionZ(int mapGridZ)
    {
        return Snake.snakeSize / 2 + mapGridZ * Snake.snakeSize;
    }

    void Start()
    {
        //m_wall.CreateWall();
        InitMap();
    }

    void Awake()
    {
        Instance = this;
    }
}
