using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashedEnemyColors : MonoBehaviour
{
    [SerializeField] GameObject smashedPrefab;
    GameObject[] smashed;
    bool flyTowordsPlayer=false;
    void Update()
    {
        
    }
    private void Start()
    {

        StartCoroutine(smashedPhases());
    }
    IEnumerator smashedPhases()
    {
        flyTowordsPlayer = false;
        yield return new WaitForSeconds(1);
        flyTowordsPlayer = true;
    }
    void flyAwayFromEnemy()
    {

    }
    void flyToPlayer(Transform player)
    {
        //smashed.transform.position = Vector2.MoveTowards(smashed.transform.position,player.position,Time.deltaTime);
    }
}
