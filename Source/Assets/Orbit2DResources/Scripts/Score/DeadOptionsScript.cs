using UnityEngine;

public class DeadOptionsScript : MonoBehaviour
{
    
    private Rect _respawn = new Rect();
    private Rect but;

   


    public void Start()
    {
      
        _respawn.width = Screen.width / 5;
        _respawn.height = Screen.height / 8;
        _respawn.center = new Vector2(Screen.width / 2, Screen.height / 2 - Screen.height / 14);
        but.width = (Screen.width / 10) * 2;
        but.height = (Screen.height / 16) * 2;
        but.center = new Vector2(Screen.width / 2, Screen.height / 4);
        Banner.ShowBanner();
        
  
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(0);
        }
        if (Input.touchCount > 0 && _respawn.Contains(Input.GetTouch(0).position))
            //if (Input.GetMouseButtonDown(0) && _respawn.Contains(Input.mousePosition))

        {
            PlayerPrefs.Save();
            Application.LoadLevel(1);
           
        }
        if (Input.touchCount > 0 && but.Contains(Input.GetTouch(0).position))
            //if (Input.GetMouseButtonDown(0) && but.Contains(Input.mousePosition))
        {

            PlayerPrefs.Save();
            Application.LoadLevel(0);
        }
    }
   
}


