using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    public bool isDead = false;
    public AudioClip m_deadClip;
    protected static AudioSource m_audio;

	// Use this for initialization
	void Awake () 
    {
        Instance = this;
	}
	
	// Update is called once per frame
	void Start () 
    {
        m_audio = this.audio;
	}

    void OnGUI()
    {
        if (isDead)
        {
            m_audio.PlayOneShot(m_deadClip);
            Application.LoadLevel("GameOver");
        }
    }
}
