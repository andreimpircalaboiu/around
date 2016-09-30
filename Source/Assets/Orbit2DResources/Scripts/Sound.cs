using System;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    private Rect soundONOff;
    public Sprite soundOn, soundOff;
    private string isOn = "true";
    public Image bla;
    // Use this for initialization
    void Awake()
    {
        if (PlayerPrefs.GetString("sound", "false") == "false")
        {
            bla.sprite = soundOff;
            isOn = "true";
        }
        else
        {
            bla.sprite = soundOn;

            isOn = "false";
        }
    }
    
    void Start()
    {
          if (PlayerPrefs.GetString("sound","false")== "false")
                {
                    bla.sprite = soundOff;
                    isOn = "true";
                }
                else
                {
                    bla.sprite = soundOn;
                    
                    isOn = "false";
                }
        
        soundONOff.width = Screen.width / 6;
        soundONOff.height = 3*Screen.height / 18;
        soundONOff.center = new Vector2(11*Screen.width/12, 2);
             
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))

        //    if (Input.GetMouseButtonDown(0) && soundONOff.Contains(Input.mousePosition))
                if (Input.touchCount > 0 && soundONOff.Contains(Input.GetTouch(0).position)&& Input.GetTouch(0).phase==TouchPhase.Ended)
                {



                if (PlayerPrefs.GetString("sound", "false") == "false")
                {
                    bla.sprite = soundOn;
                    isOn = "true";
                }
                else
                {
                    bla.sprite = soundOff;

                    isOn = "false";
                }
                PlayerPrefs.SetString("sound", isOn);
                AudioListener.pause = Convert.ToBoolean(PlayerPrefs.GetString("sound", "false"));


            }

    }
}