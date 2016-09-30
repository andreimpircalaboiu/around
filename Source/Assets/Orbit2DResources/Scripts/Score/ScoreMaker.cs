using UnityEngine;
using UnityEngine.UI;

public class ScoreMaker : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;
    private int _score;
    public new string name;
    private int highScore = 0;
    private string highScoreKey = "HighScore";
	// Use this for initialization

	void Start () {
        _score = 0;
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        UpdateScore();
        highScoreText.text = highScore.ToString();
        
	}
	
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.name == name)
        {
         
            _score++;
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        scoreText.text = _score.ToString();
        PlayerPrefs.SetInt("Score", _score);
        
    }
}
