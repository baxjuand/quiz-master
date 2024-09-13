using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreKeeper scoreKeeper;
    void Awake()
    {
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
    }

    public void ShowFinalScore()
    {
        if (scoreKeeper.CalculateScore() <= 50)
        {
            finalScoreText.text = "Don't give up! Every steps brings you closer to victory\nYou Scored: " + scoreKeeper.CalculateScore() + "%";
        }
        else if (scoreKeeper.CalculateScore() >= 51 && scoreKeeper.CalculateScore() <= 79)
        {
            finalScoreText.text = "Great job ! You're close to the top!\nYou Scored: " + scoreKeeper.CalculateScore() + "%";
        }
        else if (scoreKeeper.CalculateScore() >= 80)
        {
            finalScoreText.text = "Outstanding! You're on top of the game\nYou Scored: " + scoreKeeper.CalculateScore() + "%";
        }
        
    }

}
