using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
    public Wall m_wall;
    public const int mapX = 16;
    public const int mapZ = 16;
    public static float mapSizeX = mapX * Snake.snakeSize;
    public static float mapSizeZ = mapZ * Snake.snakeSize;

    void Start()
    {
        m_wall.CreateWall();
    }
}
