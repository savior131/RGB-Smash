using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    int score  =-1;
    int compo = 1;
    float comboTimer;
    [SerializeField] float resetCompoTimer;
    public event Action onScoreChange;
    public event Action onCompoIncreace;

    private void Start()
    {
        comboTimer = resetCompoTimer;
        onCompoIncreace();
    }

    private void Update()
    {
        comboTimer -= Time.deltaTime;
        if (comboTimer <= 0)
        {
            comboTimer = 0;
            resetCompo();
        }
    }
    public void increaseScore()
    {
        score += (10 * compo);
        comboTimer = resetCompoTimer;
        if (onScoreChange != null) onScoreChange();
    }
    public void increaseCompo()
    {
        compo += 1;
        if(onCompoIncreace != null) onCompoIncreace();
    }
    public void resetCompo()
    {
        compo = 1;
        if (onCompoIncreace != null) onCompoIncreace();
    }

    public int getScore()
    {
        return score;
    }
    public int getCompo()
    {
        return compo;
    }


}
