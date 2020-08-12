using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    public TMP_Text scoreLabel;

    private int currentScore;

    public Animator scoreLabolanimator;

    public void Start()
    {
        scoreLabel.text = "0";
    }

    public void AddPoints(int amount)
    {
        currentScore += 10;
        scoreLabel.text = currentScore.ToString();
        scoreLabolanimator.SetTrigger("scoreanimation");
    }

    public void ReducePoints(int amount)
    {
        currentScore -= 10;
        scoreLabel.text = currentScore.ToString();
    }
}
