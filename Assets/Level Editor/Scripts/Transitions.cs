using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitions : MonoBehaviour
{
    public Animator transition;

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }
    IEnumerator LoadLevel(string sceneName)
    {
        transition.SetTrigger("Unload");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Unload");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }

    public void ReloadScene()
    {
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Unload");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        StartCoroutine(LoadMenu());
    }
    IEnumerator LoadMenu()
    {
        transition.SetTrigger("Unload");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Menu");
    }
}