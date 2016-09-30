using System;
using UnityEngine;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

    public Canvas currentCanvas;
    public Canvas nextCanvas;
    private Rect leftArrow;
    private Rect rightArrow;
    public Image firstImage;
    public Image secondImageA;
    public Image secondImageB;
    public Image thirdImage;
    public Image fourthImage;
    private string currentImageString;
    private bool clicked;
    private bool moveImagesBool = false;
    public float timestamp = 0.0f;
    void Start()
    {
        rightArrow.center = new Vector2(Screen.width - Screen.width / 11, Screen.height / 2 - Screen.width / 24);
        rightArrow.height = Screen.width / 8;
        rightArrow.width = Screen.width / 7;
        leftArrow.center = new Vector2(Screen.width / 24, Screen.height / 2 - Screen.width / 24);
        leftArrow.height = Screen.width / 8;
        leftArrow.width = Screen.width / 7;
        currentImageString = firstImage.name;
        firstImage.active = true;
        secondImageA.active = false;
        secondImageB.active = false;
        thirdImage.active = false;
        fourthImage.active = false;
        nextCanvas.enabled = false;
        nextCanvas.active = false;
        clicked = false;
        Banner.HideBanner();
    }



    void Update()
    {
        
        if (moveImagesBool == true && Time.realtimeSinceStartup >= timestamp)
        {
           
            MoveImages();
            timestamp = Time.realtimeSinceStartup + 0.4f;
        }
        if (Input.touchCount > 0 && rightArrow.Contains(Input.GetTouch(0).position)&& Input.GetTouch(0).phase == TouchPhase.Ended)
        //if (Input.GetMouseButtonDown(0) && rightArrow.Contains(Input.mousePosition))
        {

            clicked = true;
            if ( currentImageString == fourthImage.name && clicked == true)
            {
                clicked = false;
                currentImageString = firstImage.name;
                fourthImage.active = false;
                currentCanvas.enabled = false;
                currentCanvas.active = false;
                nextCanvas.enabled = true;
                nextCanvas.active = true;

            }


            if ( currentImageString == thirdImage.name && clicked == true)
            {
                clicked = false;
                currentImageString = fourthImage.name;
                fourthImage.active = true;
                thirdImage.active = false;


            }

            if ( (currentImageString == secondImageA.name || currentImageString == secondImageB.name) && clicked == true)
            {
                clicked = false;
                currentImageString = thirdImage.name;
                thirdImage.active = true;
                secondImageA.active = false;
                secondImageB.active = false;
                moveImagesBool = false;


            }

            if ( currentImageString == firstImage.name && clicked == true)
            {
                clicked = false;
                currentImageString = secondImageA.name;
                secondImageA.active = true;
                secondImageB.active = false;
                firstImage.active = false;
                moveImagesBool = true;
                timestamp = 0f;

            }

        }
        if (Input.touchCount > 0 && leftArrow.Contains(Input.GetTouch(0).position) && Input.GetTouch(0).phase == TouchPhase.Ended)
        //if (Input.GetMouseButtonDown(0) && leftArrow.Contains(Input.mousePosition))
        {

            clicked = true;
            if ( currentImageString == firstImage.name && clicked == true)
            {
                clicked = false;
                currentImageString = firstImage.name;
                firstImage.active = false;
                currentCanvas.enabled = false;
                currentCanvas.active = false;
                nextCanvas.enabled = true;
                nextCanvas.active = true;

            }

            if ( (currentImageString == secondImageA.name || currentImageString == secondImageB.name) && clicked == true)
            {
                clicked = false;
                currentImageString = firstImage.name;
                secondImageA.active = false;
                secondImageB.active = false;
                firstImage.active = true;
                moveImagesBool = false;

            }

            if (currentImageString == thirdImage.name && clicked == true)
            {
                clicked = false;
                currentImageString = secondImageA.name;
                thirdImage.active = false;
                secondImageA.active = true;
                secondImageB.active = false;
                moveImagesBool = true;
                timestamp = 0f;


            }

            if (  currentImageString == fourthImage.name && clicked == true)
            {
                clicked = false;
                currentImageString = thirdImage.name;
                fourthImage.active = false;
                thirdImage.active = true;
            }
        }
    }
  

    void MoveImages()
    {
        bool imageAState = secondImageA.IsActive();
        // Debug.Log(imageAState);
        secondImageA.active = !imageAState;
        //Debug.Log(secondImageA.active);
        bool imageBState = secondImageB.IsActive();
        //Debug.Log(imageBState);
        secondImageB.active = !imageBState;
        //Debug.Log(secondImageB.active);
    }
}
