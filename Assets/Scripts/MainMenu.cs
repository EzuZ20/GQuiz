using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject highscore;
    public GameObject credits;
    public GameObject[] InGameObjects;
    public GameObject NameOfGame;
    public TextMeshProUGUI HighScoreMenuText;

    public QuizManager quizManager;
    public SaveObject saveObject;

    // Start is called before the first frame update
    void Start()
    {
        if(quizManager == null)
            quizManager = FindObjectOfType<QuizManager>();

        if(saveObject == null)
            saveObject = FindObjectOfType<SaveObject>();
        menu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        menu.SetActive(false);

        for(int i = 0; i < InGameObjects.Length; i++)
        {
            InGameObjects[i].SetActive(true);
        }
        NameOfGame.SetActive(false );
    }

    public void ShowHighScore()
    {
        highscore.SetActive(true);

        if (saveObject == null)
            saveObject = FindObjectOfType<SaveObject>();

        HighScoreMenuText.text = saveObject.SavedScore.ToString();
        NameOfGame.SetActive(false);
    }

    public void HighScoreToMenu()
    {
        highscore.SetActive(false);
        NameOfGame.SetActive(true);
    }

    public void ShowCredits()
    {
        credits.SetActive(true);
    }

    public void CreditsToMain()
    {
        credits.SetActive(false);
        NameOfGame.SetActive(true);
    }
}
