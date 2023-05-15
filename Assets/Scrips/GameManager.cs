using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndScreen endScreen;

    void Start()
    {
        quiz = FindObjectOfType<Quiz>();
        endScreen = FindObjectOfType<EndScreen>();

        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);    
    }


    void Update()
    {
        if (quiz.isComplete)
        {
            Invoke("EndGameRoutine",5f);
        } 
        
    }

    void EndGameRoutine()
    {
        quiz.gameObject.SetActive(false);
        endScreen.gameObject.SetActive(true);
        endScreen.showFinalScore();
    }

    public void OnReplayLevel()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
