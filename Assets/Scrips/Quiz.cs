using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
     [SerializeField] TextMeshProUGUI _quastionText;
     [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
     QuestionSO _currentQuastion;

     [Header("Answers")]
     [SerializeField] GameObject[] _answerButtons;
     [SerializeField] int _correctAnswerIndex;
     bool hasAnswerdEarly = true;
     [SerializeField] AudioSource clapsSound;
     [SerializeField] AudioSource buzzerSound;

     [Header("Sprites")]
     [SerializeField] Sprite defultSprite;
     [SerializeField] Sprite correctSprite;

     [Header("Timer")]
     [SerializeField] Image timerImage;
     Timer timer;

     [Header("Scoring")]
     [SerializeField] TextMeshProUGUI scoretext;
     ScoreKeeper scoreKeeper;

    [Header("Slider")]
    [SerializeField] Slider slider;

    public bool isComplete = false;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        slider.maxValue = questions.Count;
        slider.value = 0;
        clapsSound = GetComponent<AudioSource>();
        buzzerSound = GetComponent<AudioSource>();

    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            hasAnswerdEarly = false;
            GetNewQuestion();
            timer.loadNextQuestion = false;
        }
        else if (!hasAnswerdEarly && !timer.isAnsweringQuestion )
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    public void OnAnswerSelected (int i)
    {
        hasAnswerdEarly = true;    
        DisplayAnswer(i);
        SetButtonState(false);
        timer.CencelTimer();
        scoretext.text = "Score: " + scoreKeeper.CalculateScore() + "%";

        if (slider.value == slider.maxValue)
        {
            isComplete = true;
        }
    }

    void DisplayQuastion()
    {
         _quastionText.text = _currentQuastion.GetQuestion();
    
        for (int i=0; i<_answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = _answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = _currentQuastion.GetAnswerByIndex(i);
        }
    }

    void SetButtonState (bool state)
    {
        for (int i=0; i< _answerButtons.Length; i++)
        {
            Button button = _answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
    void GetNewQuestion()
    {
        if (questions.Count > 0)
        {
            SetButtonState(true);
            SetDefultButtonSprite();
            GetRandomQuestion();
            DisplayQuastion();
            scoreKeeper.AddQuestionsSeen();
            
        }
    }
    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        _currentQuastion = questions[index];
        if (questions.Contains(_currentQuastion))
        {
        questions.Remove(_currentQuastion);
        }
    }
    void SetDefultButtonSprite()
    {
        for(int i=0; i<_answerButtons.Length; i++)
        {
            Image buttonImage = _answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defultSprite;
        }

    }

    void DisplayAnswer(int i)
    {
         if (i == _currentQuastion.GetCorrectAnswerIndex()) 
        {
            _quastionText.text = "Correct!";
            Image buttonImage = _answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = correctSprite;
            scoreKeeper.AddCorrentAnswers();
            clapsSound.Play();
        }
        else 
        {
            _quastionText.text = "YOU ARE A LOSER!, the correct answer is: \n"
            + _currentQuastion.GetAnswerByIndex(_currentQuastion.GetCorrectAnswerIndex());
            Image buttonImage = _answerButtons[_currentQuastion.GetCorrectAnswerIndex()].GetComponent<Image>();
            buttonImage.sprite = correctSprite;
            buzzerSound.Play();
            
        }
        addOneToSlide();
    }

    void addOneToSlide()
    {
        slider.value += 1;
    }
}
