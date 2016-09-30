using UnityEngine;

public class PlayerButScript : MonoBehaviour {

    private Rect but;
	void Start () {
        but.width = Screen.width / 5;
        but.height = Screen.height / 8;
        but.center = new Vector2(Screen.width / 2, Screen.height / 2);

	}
	
	// Update is called once per frame
	void Update () {
	if(Input.touchCount>0&&but.Contains(Input.GetTouch(0).position))
        //if(Input.GetMouseButtonDown(0)&& but.Contains(Input.mousePosition))
        {
            Debug.Log("button pressed");

            Application.LoadLevel(2);
        }
	}
}
