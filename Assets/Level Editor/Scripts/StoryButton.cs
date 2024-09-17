using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryButton : MonoBehaviour
{
    public Animator transition;
    public void Continue()
    {
        StartCoroutine(LoadLevel((SceneManager.GetActiveScene().buildIndex + 1)));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("End");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
}
