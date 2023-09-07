using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    [SerializeField] Animator transition;
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
