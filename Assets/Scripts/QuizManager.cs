using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsNAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject QuizPanel;
    public GameObject GOPanel;
    public GameObject HintPanel;


    public GameObject[] InGameObjects;
    public Image QuestionImage;
    public TMP_Text ScoreTxt;

    int totalQuestions = 0;
    public int score;
    public float TimeBetweenQuestions = 0.5f;

    public HintScript hintScript;
    public SaveObject saveObject;

    public TextMeshProUGUI HighScoreCounter;

    private void Start()
    {
        if (saveObject == null)
            saveObject = FindObjectOfType<SaveObject>();

        //HighScoreCounter.text = saveObject.SavedScore.ToString();
        HighScoreCounter.text = score.ToString();
        totalQuestions = QnA.Count;
        GOPanel.SetActive(false);
        generateQuestion();
        saveObject.Load(saveObject.SaveFileName);
    }

    public void GameOver()
    {
        QuizPanel.SetActive(false);
        GOPanel.SetActive(true);
        HintPanel.SetActive(false);
        for (int i = 0; i < InGameObjects.Length; i++)
        {
            InGameObjects[i].SetActive(false);
        }

        ScoreTxt.text = score + "/" + totalQuestions;

        saveObject.Save(saveObject.SaveFileName);
        //HighScoreCounter.text = saveObject.SavedScore.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
    }

    public void Correct()
    {
        score += 1;
        HighScoreCounter.text = score.ToString();
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(GenerateQuestionsCoRoutine());
    }

    IEnumerator GenerateQuestionsCoRoutine()
    {

        yield return new WaitForSeconds(TimeBetweenQuestions);
        generateQuestion();

    }

    IEnumerator LoseCoRoutine()
    {

        yield return new WaitForSeconds(TimeBetweenQuestions);
        GameOver();

    }

    public void Wrong()
    {
        options[QnA[currentQuestion].CorrectAnswer - 1].GetComponent<Image>().color = Color.green;
        QnA.RemoveAt(currentQuestion);
        //StartCoroutine(GenerateQuestionsCoRoutine());
        StartCoroutine(LoseCoRoutine());
    }
    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++) 
        {
            options[i].GetComponent<AnswerScript>().IsCorrect = false;
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;


            if (QnA[currentQuestion].FlagQuestion == false)
            {
                options[i].transform.GetChild(1).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i];
                options[i].GetComponent<AnswerScript>().FlagImage.enabled = false;

            }
            else
            {
                options[i].transform.GetChild(1).GetComponent<TMP_Text>().text = "";
                options[i].GetComponent<AnswerScript>().FlagImage.enabled = true;
                options[i].GetComponent<AnswerScript>().FlagImage.sprite = QnA[currentQuestion].AnswerFlags[i];

            }
            
            
            if (QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent <AnswerScript>().IsCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionImage.sprite = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }

    }

    public void Update()
    {
        if(Input.GetKey(KeyCode.Escape)) 
        {
            Application.Quit();
        }
    }
}
