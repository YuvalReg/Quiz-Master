using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int _correctAnswers = 0;
    int _questionsSeen = 0;
    
    public int GetCorrectAnswers()
    {
        return _correctAnswers;
    }

    public void AddCorrentAnswers()
    {
        _correctAnswers++;
    }

    public int GetQuestionsSeen()
    {
        return _questionsSeen;
    }

    public void AddQuestionsSeen()
    {
        _questionsSeen++;
    }

    public int CalculateScore()
    {
        return (int)( _correctAnswers / (float)_questionsSeen * 100 );
    }
}
