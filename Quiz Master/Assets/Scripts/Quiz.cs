using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    Image buttonImage;
    TextMeshProUGUI buttonTextColor;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Color correctAnswerTextColor;
    [SerializeField] Color defaultAnswerTextColor;
    void Start()
    {
        //DisplayQuestion();
        GetNextQuestion();
    }

    public void OnAnswerSelected(int index)
    {
        

        if (index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonTextColor = answerButtons[index].GetComponentInChildren<TextMeshProUGUI>();
            buttonTextColor.color = correctAnswerTextColor;
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswerIndex = question.GetCorrectAnswerIndex();
            string correctAnswer = question.GetAnswer(correctAnswerIndex);
            questionText.text = "Wrong. The correct answer is:\n" + correctAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            buttonTextColor = answerButtons[correctAnswerIndex].GetComponentInChildren<TextMeshProUGUI>();
            buttonTextColor.color = correctAnswerTextColor;
        }

        SetButtonState(false);
    }

    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonApperance();
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();


        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;

        }
    }

    void SetDefaultButtonApperance()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
            buttonTextColor = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonTextColor.color = defaultAnswerTextColor;
        }

    }
}
