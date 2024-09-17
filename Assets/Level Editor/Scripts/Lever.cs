using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lever : MonoBehaviour
{
    void Start()
    {
        test();
    }

    void test()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Level 2");
        }
    }
}
