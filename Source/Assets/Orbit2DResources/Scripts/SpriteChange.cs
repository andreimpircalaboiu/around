using UnityEngine;
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour {
    public Sprite Sound;
    public Sprite NoSound;
    public Image image;
    private Rect butt = new Rect(Screen.width - (Screen.width / 10), 0, Screen.width, Screen.height - (Screen.height / 16) * 15);
    private bool _sOrNs=true;
    // Use this for initialization
	void Start () {
        image.sprite = Sound;
        Debug.Log("initialize");
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.touchCount > 0 && butt.Contains(Input.GetTouch(0).position) && Input.GetTouch(0).phase == TouchPhase.Ended)
        //if(Input.GetMouseButtonDown(0)&&butt.Contains(Input.mousePosition))
        {
            if (_sOrNs)
            {
                image.sprite = NoSound;
                Debug.Log("no sound");
                _sOrNs=!_sOrNs;
            }
            else
            {
                image.sprite = Sound;
                Debug.Log("sound");
                _sOrNs = !_sOrNs;
            }
        }
	}
}
