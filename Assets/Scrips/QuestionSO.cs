using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string _question = "Enter new question text here";
    [SerializeField] string[] _answers = new string[4];
    [SerializeField] int _correctAnswerIndex;

    /* Get methods to void aliasing by returning a copy of the private varibles */
    public string GetQuestion (){
        return _question; 
    }

    public int GetCorrectAnswerIndex () {
        return _correctAnswerIndex;
    }

    public string GetAnswerByIndex(int i) {
        return _answers[i];
    }



}
