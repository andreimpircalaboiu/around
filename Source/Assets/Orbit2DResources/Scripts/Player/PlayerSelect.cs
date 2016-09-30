using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    private Rect _play;
    private Rect _tutorialRect;
    public Canvas currentCanvas;
    public Canvas nextCanvas;
    public Image firstImage;
    public AudioSource pow;
    void Awake()
    {

        if (Banner.BannerIsLoaded)
        {
            Banner.DestroyBanner();
            Banner.BannerIsLoaded = false;
        }
        Banner.RequestBanner();
    }
    void Start()
    {
        _play.center = new Vector2(Screen.width / 2 - Screen.width / 14, Screen.height / 2 - Screen.width / 14 * 4);
        _play.height = Screen.width / 7 + Screen.width / 14;
        _play.width = Screen.width / 7 + Screen.width / 14;
        _tutorialRect.width = Screen.width / 6 + Screen.width / 12;
        _tutorialRect.height = 3 * Screen.height / 18;
        _tutorialRect.center = new Vector2(2, 2);
        nextCanvas.enabled = false;
        nextCanvas.active = false;
        try
        {
            var firstPlayExists = Convert.ToBoolean(PlayerPrefs.GetString("firstPlay", "true"));
        }
        catch (Exception)
        {
            PlayerPrefs.SetString("firstPlay", "true");
        }
        Banner.ShowBanner();
    }

    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DialogManager.Instance.ShowSelectDialog("Alert", "Are you sure you want to quit the game ?", (bool result) =>
            {
                if (result)
                {
                    PlayerPrefs.Save();
                    Application.Quit();
                }
            });
        }
        if (Input.touchCount > 0 && _tutorialRect.Contains(Input.GetTouch(0).position))
            //if (Input.GetMouseButtonDown(0) && _tutorialRect.Contains(Input.mousePosition))
        {
            nextCanvas.enabled = true;
            nextCanvas.active = true;
            firstImage.active = true;
            currentCanvas.enabled = false;
            currentCanvas.active = false;
        }

        if (Input.touchCount > 0 && _play.Contains(Input.GetTouch(0).position))
            //if (Input.GetMouseButtonDown(0) && _play.Contains(Input.mousePosition))
        {
            
            if (Convert.ToBoolean( PlayerPrefs.GetString("sound", "true")) == true)
            {
                pow.Play();
            }
            if (Convert.ToBoolean(PlayerPrefs.GetString("firstPlay", "true")) == true)
            {
                PlayerPrefs.SetString("firstPlay", "false");
                nextCanvas.enabled = true;
                nextCanvas.active = true;
                firstImage.active = true;
                currentCanvas.enabled = false;
                currentCanvas.active = false;
                
            }
            else
            {
                PlayerPrefs.SetInt("player", 0);

                PlayerPrefs.Save();
                Application.LoadLevel(1);
            }
        }
    }
}
