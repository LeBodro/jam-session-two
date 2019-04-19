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
            Input.GetKeyDown(KeyCode.A) && 
            Input.GetKeyDown(KeyCode.K) && 
            Input.GetKeyDown(KeyCode.L) && 
            Input.GetKeyDown(KeyCode.S)
        ) {
            StartGame();
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
