using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    [SerializeField]
    Animator transition;
    [SerializeField]
    string sceneName;

    public void RetryGame()
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    public void QuitGame()
    {
        StartCoroutine(LoadLevel("Menu"));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        transition.SetTrigger("End");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(sceneName);
    }
}
