using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public TeaBag[] teaBags;
    public float left;
    public float right;
    public float duration = 15;
    public Text declaration;
    public AudioSource tada;

    bool ended;
    float width;

    void Start()
    {
        ended = false;
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
        if (duration <= 0 && !ended)
        {
            ended = true;
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        int winner = 0;
        float score = 0;
        for (int i = 0; i < teaBags.Length; i++)
        {
            if (teaBags[i].advance > score)
            {
                score = teaBags[i].advance;
                winner = i;
            }
            teaBags[i].enabled = false;
        }
        tada.Play();
        declaration.text = string.Format("A winner is {0}!", teaBags[winner].name);
        teaBags[winner].GetComponent<Animation>().Play();
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
