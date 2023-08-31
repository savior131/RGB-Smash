using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    Animator transition;

    void Start()
    {
        transition = GameObject.FindGameObjectWithTag("Level Loader").GetComponent<Animator>();  
    }
    public void LoadThatLevel(int level)
    {
        StartCoroutine(loadLevel(level));
    }
    IEnumerator loadLevel(int level)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }
}
