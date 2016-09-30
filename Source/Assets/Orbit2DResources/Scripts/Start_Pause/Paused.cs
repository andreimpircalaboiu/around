using UnityEngine;
using UnityEngine.UI;

public class Paused : MonoBehaviour
{
    public StartScript script1;
    public OrbitingObject script2;
    public SatelliteDestroyerScript script3;
    public Destroy script4;
    public SatelliteCreator script5;
    public ScoreMaker script6;
    public Image PauseImgFromPauseCanv;
    public Image RestartImgFromPauseCanv;



    public GameObject pause1;

    private bool playOrPause = false;
    public Canvas pauseCanv;
    private Rect pauseBtn = new Rect(Screen.width - (Screen.width / 10), Screen.height - (Screen.height / 28) * 4, Screen.width / 10, (Screen.height / 28) * 2);
    private Rect pauseBtn2 = new Rect(Screen.width - (Screen.width / 10), Screen.height - Screen.height / 14, Screen.width / 10, (Screen.height / 28) * 2);
    private Rect restartBtn = new Rect(0, Screen.height - (Screen.height / 28) * 4, Screen.width / 5, (Screen.height / 28) * 2);
    private Rect restartBtn2 = new Rect(0, Screen.height - Screen.height / 14, Screen.width / 5, (Screen.height / 28) * 2);

    private Vector3 _pauseBtnPositionWithoutBanner;
    private Vector3 _pauseBtnDefault;
    private Vector3 _restartBtnPositionWithoutBanner;
    private Vector3 _restartBtnDefault;


    void Start()
    {
        pauseCanv.enabled = false;
        Banner.ShowBanner();
        _pauseBtnPositionWithoutBanner = PauseImgFromPauseCanv.transform.position + new Vector3(0, (Screen.height / 28) * 2, 0);
        _pauseBtnDefault = PauseImgFromPauseCanv.transform.position;
        _restartBtnPositionWithoutBanner= RestartImgFromPauseCanv.transform.position + new Vector3(0, (Screen.height / 28) * 2, 0);
        _restartBtnDefault = RestartImgFromPauseCanv.transform.position;
    }




    void MoveBtn()
    {
        pause1.transform.position = new Vector3(pause1.transform.position.x, Screen.height - 180, pause1.transform.position.z);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(0);
        }
        Pause();
        ChangePlayer();




    }

    private void Pause()
    {
        if (Banner.IsLoaded())
            PauseWithBanner();

        else
            PauseWithoutBanner();


    }

    private void PauseWithBanner()
    {
        if (Input.touchCount > 0 && pauseBtn.Contains(Input.GetTouch(0).position) &&
       Input.GetTouch(0).phase == TouchPhase.Ended)
       // if (Input.GetMouseButtonDown(0) && pauseBtn.Contains(Input.mousePosition))
        {
            Debug.Log("Unpause With Banner");
            pauseCanv.enabled = false;
            ScriptsEnabled();
            pause1.SetActive(true);
            Time.timeScale = 1;
            playOrPause = !playOrPause;
            Banner.HideBanner();
        }
        //vezi ca iti intra in ambele if-uri cand ii dai unpause 

        if (Input.touchCount > 0 && pauseBtn2.Contains(Input.GetTouch(0).position) &&
        Input.GetTouch(0).phase == TouchPhase.Ended && pauseCanv.enabled == false)
     //   if (Input.GetMouseButtonDown(0) && pauseBtn2.Contains(Input.mousePosition))
        {
            Debug.Log("Pause With Banner");
            pauseCanv.enabled = true;
            pause1.SetActive(true);
            PauseImgFromPauseCanv.transform.position = _pauseBtnDefault;
            RestartImgFromPauseCanv.transform.position = _restartBtnDefault;
            ScriptsDisabled();
            Time.timeScale = 0;
            playOrPause = !playOrPause;
            Banner.ShowBanner();

        }
    }

    private void PauseWithoutBanner()
    {
        if (Time.timeScale == 0)
        {
            if (Input.touchCount > 0 && pauseBtn2.Contains(Input.GetTouch(0).position) &&
            Input.GetTouch(0).phase == TouchPhase.Ended)
                //if (Input.GetMouseButtonUp(0) && pauseBtn2.Contains(Input.mousePosition))
                {
               // Debug.Log("Unpause Without Banner");
                pauseCanv.enabled = false;
                ScriptsEnabled();
                Time.timeScale = 1;
                pause1.SetActive(true);

                playOrPause = !playOrPause;
                Banner.HideBanner();
            }

        }
        else
        {
            if (Input.touchCount > 0 && pauseBtn2.Contains(Input.GetTouch(0).position) &&
            Input.GetTouch(0).phase == TouchPhase.Ended && pauseCanv.enabled == false)
            //if (Input.GetMouseButtonUp(0) && pauseBtn2.Contains(Input.mousePosition))
            {

            //    Debug.Log("Pause Without Banner");
                pauseCanv.enabled = true;
                pause1.SetActive(false);
                PauseImgFromPauseCanv.transform.position = _pauseBtnPositionWithoutBanner;
                RestartImgFromPauseCanv.transform.position = _restartBtnPositionWithoutBanner;
                ScriptsDisabled();
                Time.timeScale = 0;
                playOrPause = !playOrPause;
                Banner.ShowBanner();

            }
        }
    }
    private void ChangePlayer()
    {
        if (Banner.IsLoaded())
        {
            if (pauseCanv.enabled == true && Input.touchCount > 0 && restartBtn.Contains(Input.GetTouch(0).position))
            //if (Input.GetMouseButtonDown(0) && restartBtn.Contains(Input.mousePosition))
            {
                Application.LoadLevel(0);
            }
        }
        else
        {
            if (pauseCanv.enabled == true && Input.touchCount > 0 && restartBtn2.Contains(Input.GetTouch(0).position))
            //if (Input.GetMouseButtonDown(0) && restartBtn.Contains(Input.mousePosition))
            {
                Application.LoadLevel(0);
            }
        }
    }


    public void ScriptsDisabled()
    {

        script1.enabled = false;
        script2.enabled = false;
        script3.enabled = false;
        script4.enabled = false;
        script5.enabled = false;
        script6.enabled = false;
    }
    public void ScriptsEnabled()
    {
        script1.enabled = true;
        script2.enabled = true;
        script3.enabled = true;
        script4.enabled = true;
        script5.enabled = true;
        script6.enabled = true;

    }


}
