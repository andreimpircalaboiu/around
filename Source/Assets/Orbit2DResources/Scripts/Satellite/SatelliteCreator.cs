using System;
using UnityEngine;

public class SatelliteCreator : MonoBehaviour {

    private float time=3.5f;
    private float repeatRate;
    private float scoreCounter;
    public ScoreMaker scorer;
    private int realTimeScore=0;
    private Difficulty difficulty = Difficulty.Easy;
    public GameObject Orbit;
    private SpriteRenderer _spriteRendererOrbit;

    void Awake()
    {
        
    }

    void Start () {
        repeatRate = 0.9f;
        InvokeRepeating("Create",time, repeatRate);
	    _spriteRendererOrbit = Orbit.GetComponent<SpriteRenderer>();
        _spriteRendererOrbit.enabled = true;

	}
	void Update()
	{
	    if (realTimeScore.ToString().Equals(scorer.scoreText.text))
        return;
	    realTimeScore = Convert.ToInt32(scorer.scoreText.text);
	    SetDifficultyAndRate();
	}

    private void SetDifficultyAndRate()
    {
        var currentScore = Convert.ToInt32(scorer.scoreText.text);
        if (currentScore >= 0 && currentScore < 3)
        {
            difficulty = Difficulty.Easy;
            repeatRate = 0.9f;
        }
        if (currentScore >= 3 && currentScore < 15)
        {
            difficulty = Difficulty.Medium;
        }
        if (currentScore >= 15 && currentScore < 25)
        {
            difficulty = Difficulty.Hard;
            repeatRate = 0.7f;
        }
        if (currentScore >= 25 && currentScore < 30)
        {
            difficulty = Difficulty.VeryHard;
            repeatRate = 0.6f;
        }
        if (currentScore >= 30)
        {
            difficulty = Difficulty.Ultra;
            repeatRate = 0.5f;
            _spriteRendererOrbit.enabled = false;
        }
    }

    void Create()
    {
        var factory = gameObject.AddComponent<SatelliteFactory>();
        var formation = factory.Create(difficulty);
        formation.GenerateSatellites();
    }
}
