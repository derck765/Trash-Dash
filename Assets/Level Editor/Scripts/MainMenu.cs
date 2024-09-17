using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Animator transition;

    public void Level1()
    {
        StartCoroutine(LoadLevel("Loading1"));
    }
    public void Level2()
    {
        StartCoroutine(LoadLevel("Loading2"));
    }
    public void Level3()
    {
        StartCoroutine(LoadLevel("Loading3"));
    }
    public void Tutorial()
    {
        StartCoroutine(LoadLevel((SceneManager.GetActiveScene().buildIndex + 1)));
    }

    public void Credits()
    {
        StartCoroutine(LoadLevel("Credits"));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("End");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadLevel(string sceneName)
    {
        transition.SetTrigger("End");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(sceneName);
    }
}
