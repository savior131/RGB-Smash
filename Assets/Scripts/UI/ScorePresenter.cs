using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField] PlayerScore playerScore;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI compoText;
    [SerializeField] TextMeshProUGUI scoreTextGameOver;
    [SerializeField] TextMeshProUGUI highScoreTextGameOver;
    int score = 0;
    string space = " X";
    private void Start()
    {
        playerScore.onScoreChange += setScoreTextUI;
        playerScore.onCompoIncreace += setCompoTextUI;
        highScoreTextGameOver.text = "high score: " + (PlayerPrefs.GetInt("HighScore", 0) + 1).ToString();
    }

    public void setScoreUIGameOver()
    {
        scoreTextGameOver.text = (playerScore.getScore() + 1).ToString();

        if (playerScore.getScore() > PlayerPrefs.GetInt("HighScore" , 0))
        {
            PlayerPrefs.SetInt("HighScore", playerScore.getScore());
            highScoreTextGameOver.text = "high score: " + (playerScore.getScore() + 1).ToString();
        }
    }

    private void setScoreTextUI()
    {
        StartCoroutine(scoreUptadeUI());
    }
    private void setCompoTextUI()
    {
        compoText.text = space + playerScore.getCompo();
    }
    IEnumerator scoreUptadeUI()
    {
        
        while (true)
        {
            score += 1;
            scoreText.text = "" + score;
            yield return new WaitForSeconds(0.05f);
            if (score >= playerScore.getScore())
                StopAllCoroutines();
        }
    }
}
