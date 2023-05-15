using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float _timeToComplete = 10f;
    [SerializeField] float _timeToShowAnswer = 5f;
    float _timerValue;
    public float fillFraction;
    public bool isAnsweringQuestion = false;
    public bool loadNextQuestion;





    void Update()
    {
        UpdateTimer();
    }
    
    public void CencelTimer()
    {
        _timerValue = 0;
    }
    void UpdateTimer()
    {
        _timerValue -= Time.deltaTime;

        if (isAnsweringQuestion)
        {
            if (_timerValue > 0 )
            {
                fillFraction = _timerValue/ _timeToComplete;
            }
            else
            {
                isAnsweringQuestion = false;
                _timerValue = _timeToShowAnswer;
            }
        }
        else
        {
            if (_timerValue > 0)
            {
                fillFraction = _timerValue/ _timeToShowAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                _timerValue = _timeToComplete;
                loadNextQuestion = true;
            }
        }
    }
}
