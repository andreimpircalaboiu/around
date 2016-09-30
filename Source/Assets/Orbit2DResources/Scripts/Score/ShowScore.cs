using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    // Use this for initialization
    void Start()
    {
        scoreText.text = PlayerPrefs.GetInt("Score").ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

}
