using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    public bool isDead = false;

	// Use this for initialization
	void Awake () 
    {
        Instance = this;
	}
	
	// Update is called once per frame
	void Start () 
    {
	}

    void OnGUI()
    {
        if (isDead)
        {
            Application.LoadLevel("GameOver");
        }
    }
}
