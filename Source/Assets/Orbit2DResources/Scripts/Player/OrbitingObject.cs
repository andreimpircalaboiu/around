using System;
using UnityEngine;
using System.Collections;
public class OrbitingObject : MonoBehaviour
{

    private float OrbitDistance = OD2;
    private const float OD1 = 1.064f;
    private const float OD2 = 1.487f;
    private const float OD3 = 1.91f;
    private const float OD4 = 2.333f;
    private const float TimeUntilHold = 0.16f;
    private float orbitDegreesPerSec = 80.0f;
    public Transform target;
    private bool moved = false;
    private Animator anim;
    private GameObject background;
    private bool AnimPlayed;
    private float holdCount = 0;
    private bool holdState = false;
    private bool dead = false;
    public ScoreMaker scorer;
    private int highScore = 0;
    private string highScoreKey = "HighScore";
    private Rect pauseBtn = new Rect(Screen.width - (Screen.width / 10), Screen.height - ((Screen.height / 64) * 6), Screen.width, Screen.height);
    public AudioSource pow;
    private bool makesound;
    private const string name1 = "SatelliteModel1(Clone)";
    private const string name2 = "SatelliteModel2(Clone)";
    private const string name3 = "SatelliteModel3(Clone)";
    private const string name4 = "SatelliteModel4(Clone)";
    private bool IsFirstTime = true;


    // Use this for initialization
    void Awake()
    {

        if (PlayerPrefs.GetInt("interstitial", 0) == 3)
        {
            if (Banner.InterstitialIsLoaded)
            {
                Banner.DestroyInterstitial();
                Banner.InterstitialIsLoaded = false;
            }
            Banner.RequestInterstitial();

        }




    }
    void Start()
    {

        Banner.HideBanner();
        background = GameObject.Find("BackgroundAnim");
        anim = background.GetComponent<Animator>();
        //MakeOrbit(OrbitDistance);
        //Wait();
        holdState = false;
        moved = false;
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        AudioListener.pause = Convert.ToBoolean(PlayerPrefs.GetString("sound", "false"));
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == name1 || other.name == name2 || other.name == name3 || other.name == name4)
        {
            if (Convert.ToInt32(scorer.scoreText.text) > highScore)
            {
                PlayerPrefs.SetInt(highScoreKey, Convert.ToInt32(scorer.scoreText.text));
                PlayerPrefs.Save();
            }
            if (PlayerPrefs.GetInt("interstitial", 0) == 3)
            {
                Banner.ShowInterstitial();
                PlayerPrefs.SetInt("interstitial", 0);

            }
            else
            {
                PlayerPrefs.SetInt("interstitial", PlayerPrefs.GetInt("interstitial", 0) + 1);

            }

            PlayerPrefs.Save();
            Application.LoadLevel(2);
        }
    }

    public void MakeOrbit(float OrbitDistance)
    {
        if (target != null)
        {
            // Keep us at orbitDistance from target
            this.transform.position = target.position + (transform.position - target.position).normalized * OrbitDistance;
            this.transform.RotateAround(target.position, Vector3.back, orbitDegreesPerSec * Time.deltaTime);

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (IsFirstTime)
        {
            StartCoroutine(Wait());

        }
        else
        {
            if (dead == true && OrbitDistance < 2f)
            {
                OrbitDistance = OrbitDistance - 0.01f;
                if (OrbitDistance < 0.7f)
                {
                    if (Convert.ToInt32(scorer.scoreText.text) > highScore)
                    {
                        PlayerPrefs.SetInt(highScoreKey, Convert.ToInt32(scorer.scoreText.text));
                        PlayerPrefs.Save();
                    }
                    if (PlayerPrefs.GetInt("interstitial", 0) == 3)
                    {
                        Banner.ShowInterstitial();
                        PlayerPrefs.SetInt("interstitial", 0);

                    }
                    else
                    {
                        PlayerPrefs.SetInt("interstitial", PlayerPrefs.GetInt("interstitial", 0) + 1);

                    }
                    PlayerPrefs.Save();
                    Application.LoadLevel(2);
                }

            }
            else

            if (dead == true && OrbitDistance > 2)
            {
                OrbitDistance = OrbitDistance + 0.01f;
                if (OrbitDistance > 4f)
                {
                    if (Convert.ToInt32(scorer.scoreText.text) > highScore)
                    {
                        PlayerPrefs.SetInt(highScoreKey, Convert.ToInt32(scorer.scoreText.text));
                        PlayerPrefs.Save();
                    }
                    if (PlayerPrefs.GetInt("interstitial", 0) == 3)
                    {
                        Banner.ShowInterstitial();
                        PlayerPrefs.SetInt("interstitial", 0);

                    }
                    else
                    {
                        PlayerPrefs.SetInt("interstitial", PlayerPrefs.GetInt("interstitial", 0) + 1);

                    }
                    PlayerPrefs.Save();
                    Application.LoadLevel(2);
                }
            }

            if (moved == true && anim.IsInTransition(0))
            {

                if (Convert.ToInt32(scorer.scoreText.text) > highScore)
                {
                    PlayerPrefs.SetInt(highScoreKey, Convert.ToInt32(scorer.scoreText.text));
                    PlayerPrefs.Save();
                }
                dead = true;
            }

            if ((Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Stationary)) && !pauseBtn.Contains(Input.GetTouch(0).position))
            {
                holdCount += Time.deltaTime;

                if (holdCount < TimeUntilHold && Input.GetTouch(0).phase == TouchPhase.Ended)
                {

                    pow.Play();
                    SwitchTMovement();
                    makesound = true;
                }
                else
                if (holdCount > TimeUntilHold && holdState == false)
                {
                    holdState = true;
                }
                else
                if (holdState)
                {
                    if (!makesound)
                    {
                        makesound = true;
                        pow.Play();
                    }
                    HoldTMovement();
                }
            }
            MakeOrbit(OrbitDistance);
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.5f);
        IsFirstTime = false;
    }

    private void HoldTMovement()
    {
        //(Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
        if (moved == false && (OrbitDistance == OD3 || OrbitDistance == OD4))
        {

            OrbitDistance = OD4;
            moved = true;
            holdState = true;

            if (AnimPlayed == false)
            {
                anim.Play("OnSides", -1, float.NegativeInfinity);
                AnimPlayed = true;

            }

        }
        else
        if (moved == false && (OrbitDistance == OD2 || OrbitDistance == OD1))
        {

            OrbitDistance = OD1;

            holdState = true;
            if (AnimPlayed == false)
            {
                anim.Play("OnSides", -1, float.NegativeInfinity);


                AnimPlayed = true;

            }
            Debug.Log(anim.IsInTransition(0));

            moved = true;
        }
        else
        if(OrbitDistance == OD4 && moved == true && Input.GetTouch(0).phase == TouchPhase.Ended)
        {

            anim.Play("Normal", -1, float.NegativeInfinity);
            OrbitDistance = OD3;
            AnimPlayed = false;
            holdState = false;
            moved = false;
            holdCount = 0;
        }
        else
        if (OrbitDistance == OD1 && moved == true && Input.GetTouch(0).phase == TouchPhase.Ended)
        {

            anim.Play("Normal", -1, float.NegativeInfinity);
            OrbitDistance = OD2;
            AnimPlayed = false;
            moved = false;
            holdState = false;
            holdCount = 0;
        }


    }

    private void SwitchTMovement()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            if (OrbitDistance == OD2)
            {
                OrbitDistance = OD3;
            }
            else
                if (OrbitDistance == OD3)
            {
                OrbitDistance = OD2;
            }
        }
        holdCount = 0;
    }

}

