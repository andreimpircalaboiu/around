using System;
using UnityEngine;

public class Starts : MonoBehaviour {
    public AudioSource pow;
	private Rect _startButt=new Rect();
    void Start()
    {
        _startButt.width = (Screen.width / 10) * 2;
        _startButt.height = (Screen.height / 16) * 2;
        _startButt.center = new Vector2(Screen.width / 2, Screen.height / 2);
        //pow.volume = PlayerPrefs.GetInt("sound", 0);
        Debug.Log("mute is " + AudioListener.pause);
        AudioListener.pause = Convert.ToBoolean(PlayerPrefs.GetString("sound", "false"));
        Debug.Log("mute is " + AudioListener.pause);
    }
	// Update is called once per frame
	void Update () {

        if (Input.touchCount > 0 && _startButt.Contains(Input.GetTouch(0).position))
        //if (Input.GetMouseButtonDown(0) && _startButt.Contains(Input.mousePosition))
        {
            pow.Play();
            Application.LoadLevel(3);
        }
	}
}
