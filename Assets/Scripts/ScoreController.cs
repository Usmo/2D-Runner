using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public float timeScore = 1000;
    public float rewardValue = 100f;
    public float score = 0;
    public float timeScore_minimumvalue = 0;
    public float timeLeft = 0.3f;

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        deductScore();
    }
    
    public void deductScore()
    {
        if(timeLeft <= 0.0f)
        {
            if(timeScore > timeScore_minimumvalue)
            {
                timeScore -= 1;
                //Debug.Log(timeScore);
            }
            else
            {
                timeScore = timeScore_minimumvalue;
            }
            timeLeft = 0.3f;
        }
    }

    public void addScore(float value) 
    {
        score += value;
    }


    public void addRewardScore() 
    {
        addScore(rewardValue);
    }

    public void resetScore()
    {
        score = 0;
        timeScore = 1000;
    }
}
