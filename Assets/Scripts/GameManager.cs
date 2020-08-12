using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using System.Threading;

public class GameManager : MonoBehaviour
{
    public Score scoresystem;

    public Timer timer;


    public TMP_Text questionLabel;
    public TMP_Text[] optionsLabels;


    public QuestionData[] questions;

    private int currentQuestionIndex;

    private bool isGameActive;


    private void Start()
    {
        isGameActive = true;

        questionLabel.text = questions[0].question;
        for(int i = 0; i < questions[0].options.Length; i++)
        {
            optionsLabels[i].text = questions[0].options[i].option;
        }
    }

    public bool isgameActive()
    {
        return isGameActive;
    }

    public void NextQuestion()
    {
        currentQuestionIndex++;

        if(currentQuestionIndex < questions.Length)
        {
            timer.RestartTimer();

            questionLabel.text = questions[currentQuestionIndex].question;

            for (int i = 0; i < questions[currentQuestionIndex].options.Length; i++)
            {
                optionsLabels[i].text = questions[currentQuestionIndex].options[i].option;
            }
        }
        else
        {
            Debug.Log("Game Over");
            isGameActive = false;
        }

    }

    public void OptionSelected(int index)
    {
        if(questions[currentQuestionIndex].options[index].isCorrect)
        {
            scoresystem.AddPoints(10);

        }
        else
        {
            scoresystem.ReducePoints(10);
        }

        NextQuestion();
    }

}

[System.Serializable]
public struct QuestionData
{

    public string question;
    public Option[] options;

}

[System.Serializable]
public struct Option
{

    public string option;
    public bool isCorrect;

}