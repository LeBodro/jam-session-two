using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCam : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (
            Input.GetKey(KeyCode.A) &&
            Input.GetKey(KeyCode.K) &&
            Input.GetKey(KeyCode.L) &&
            Input.GetKey(KeyCode.S)
        )
        {
            StartGame();
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
