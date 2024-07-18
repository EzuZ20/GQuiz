using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HintScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ConfirmWindow;
    public string Hint;
    public QuizManager quizManager;
    public Button UseHintButton;
    public TextMeshProUGUI UseHintButtonText;
    string HintButtonStartText;

    private void Awake()
    {
    //    HintButtonStartText = "Watch ad for hint!";
    //    UseHintButtonText.text = HintButtonStartText;
        //GenerateHint();
        //HintButtonStartText = Hint;
        //UseHintButtonText.text = Hint;
    }
    void Start()
    {
        if (quizManager == null)
            quizManager = FindObjectOfType<QuizManager>();

        //HintButtonStartText = "Watch ad for hint!";
        //UseHintButtonText.text = HintButtonStartText;
        //GenerateHint();
        //HintButtonStartText = Hint;
        //UseHintButtonText.text = Hint;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CloseConfirmWindow()
    {
        ConfirmWindow.SetActive(false);
    }


    public void ToggleConfirmWindow()
    {
        ConfirmWindow.SetActive(!ConfirmWindow.activeSelf);
    }

    public void GenerateHint()
    {
        Hint = quizManager.QnA[quizManager.currentQuestion].Hint;

        UseHintButtonText.text = Hint;
        UseHintButton.interactable = false;
    }

    public void ResetHintButton()
    {

        UseHintButtonText.text = Hint;
        UseHintButton.interactable = true;
    }
}
