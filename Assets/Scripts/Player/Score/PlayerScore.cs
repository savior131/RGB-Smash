using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    int score;
    int compo = 1;
    float comboTimer;
    [SerializeField] float resetCompoTimer;

    private void Start()
    {
        comboTimer = resetCompoTimer;
    }

    private void Update()
    {
        comboTimer -= Time.deltaTime;
        if (comboTimer <= 0)
        {
            comboTimer = 0;
            resetCompo();
        }
           
        Debug.Log("Score" + score + " Compo " + compo + " Compo Timer " + comboTimer);
    }
    public void increaseScore()
    {
        score += (10 * compo);
        comboTimer = resetCompoTimer;
    }
    public void increaseCompo()
    {
        compo += 1;
    }
    public void resetCompo()
    {
        compo = 1;
    }


}
