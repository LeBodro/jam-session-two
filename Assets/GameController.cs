using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TeaBag[] teaBags;
    public float left;
    public float right;

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
    }
}
