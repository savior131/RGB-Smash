using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField] PlayerScore playerScore;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI compoText;   
    int score = 0;
    string space = " X";
    private void Start()
    {
        playerScore.onScoreChange += setScoreTextUI;
        playerScore.onCompoIncreace += setCompoTextUI;
        setCompoTextUI();
    }

    private void setScoreTextUI()
    {
        StartCoroutine(scoreUptadeUI());
    }
    private void setCompoTextUI()
    {
        compoText.text = space + playerScore.getCompo();
        if (playerScore.getScore() >= 9999)
            space = "             X";
        else if (playerScore.getScore() >= 999)
            space = "          X";
        else if(playerScore.getScore() >= 99)
            space = "      X";
        else if(playerScore.getScore() >= 9)
            space = "    X";
        else if (playerScore.getScore() >= 0)
            space = "   X";
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
