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
    }

    private void setScoreTextUI()
    {
        StartCoroutine(scoreUptadeUI());
    }
    private void setCompoTextUI()
    {
        compoText.text = space + playerScore.getCompo();
        if (playerScore.getScore() >= 10000)
            space = "         X";
        else if (playerScore.getScore() >= 1000)
            space = "      X";
        else if(playerScore.getScore() >= 100)
            space = "    X";
        else if(playerScore.getScore() >= 10)
            space = "  X";
        else if (playerScore.getScore() >= 0)
            space = " X";
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
