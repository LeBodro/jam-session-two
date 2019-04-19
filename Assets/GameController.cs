using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TeaBag[] teaBags;
    public float left;
    public float right;
    public float duration = 15;

    float width;

    void Start()
    {
        width = right - left;
    }

    void Update()
    {
        foreach (TeaBag bag in teaBags)
        {
            float target = bag.advance * width + left;
            bag.GoTo(target);
        }
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        string winner = string.Empty;
        float score = 0;
        for (int i = 0; i < teaBags.Length; i++)
        {
            if (teaBags[i].advance > score)
            {
                score = teaBags[i].advance;
                winner = teaBags[i].name;
            }
        }
        Debug.Log(string.Format("A winner is {0}!", winner));
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
