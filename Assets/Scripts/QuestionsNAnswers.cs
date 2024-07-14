using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class QuestionsNAnswers
{
    public Sprite Question;
    public string[] Answers;
    public Sprite[] AnswerFlags;
    public int CorrectAnswer;
    public string Hint;
    public bool FlagQuestion;
}
