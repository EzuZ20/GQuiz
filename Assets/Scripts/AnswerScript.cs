using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool IsCorrect = false;
    public QuizManager quizManager;

    public Color startColor;

    private void Awake()
    {
        startColor = GetComponent<Image>().color;
    }

    private void Start()
    {
        startColor = GetComponent<Image>().color;
    }
    public void Answer()
    {
        if (IsCorrect)
        {
            GetComponent<Image>().color = Color.green;
            Debug.Log("Correct Answer");
            quizManager.Correct();
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            Debug.Log("Incorrect Answer");
            quizManager.Wrong();
        }

        quizManager.hintScript.CloseConfirmWindow();
        quizManager.hintScript.ResetHintButton();
    }
}
