using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public Animator transition;
    public void Return()
    {
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel()
    {
        transition.SetTrigger("End");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Menu");
    }
}