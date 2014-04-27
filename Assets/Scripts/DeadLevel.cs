using UnityEngine;
using System.Collections;

public class DeadLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        GUI.skin.label.fontSize = 50;
        GUI.skin.label.alignment = TextAnchor.LowerCenter;
        GUI.Label(new Rect(0, Screen.height * 0.2f, Screen.width, 60), "游戏失败");

        GUI.skin.label.fontSize = 20;

        if (GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.5f, 100, 30), "再试一次"))
        {
            Application.LoadLevel("Snake");
        }
    }
}
