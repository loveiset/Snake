using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
    public const int mapX = 6;
    public const int mapZ = 6;
    public static float mapSizeX = mapX * Snake.snakeSize;
    public static float mapSizeZ = mapZ * Snake.snakeSize;

	// Use this for initialization
	void Start () 
    {
        Vector3 scale = new Vector3(0.6f,0.0f,0.6f);
        //this.transform.localScale = scale;
        //Debug.Log(collider.bounds.size.x);
        //mapX = collider.bounds.size.x;
        //mapZ = collider.bounds.size.z;
	}
}
