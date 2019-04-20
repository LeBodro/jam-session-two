using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSwap : MonoBehaviour
{
    public float lerpDuration = 10f;
    bool currentRed = false;
    bool currentGreen = false;
    bool currentBlue = false;

    bool futureRed = false;
    bool futureGreen = false;
    bool futureBlue = false;

    Color fromColor;
    Color goalColor;

    float initialLerpTime = 0f;

    public Camera bgCamera;

    // Start is called before the first frame update
    void Start()
    {
        InitializeColor();
        bgCamera.backgroundColor = GetCurrentColor();
        fromColor = GetCurrentColor();

        MakeFutureColor();
        goalColor = GetFutureColor();
        initialLerpTime = Time.time;
    }

    Color GetFutureColor()
    {
        return new Color(
            futureRed ? 1 : 0,
            futureGreen ? 1 : 0,
            futureBlue ? 1 : 0
        );
    }

    void MakeFutureColor()
    {
        int amtOfColors = 0;
        futureBlue = false;
        futureGreen = false;
        futureRed = false;

        if (currentRed) {
            amtOfColors++;
        }
        if (currentGreen) {
            amtOfColors++;
        }
        if (currentBlue) {
            amtOfColors++;
        }

        switch (amtOfColors)
        {
            case 1:
                int keepCurrentColor = Random.Range(0, 2);
                if (keepCurrentColor == 1) {
                    futureRed = currentRed;
                    futureBlue = currentBlue;
                    futureGreen = currentGreen;
                }
                int randomColorToTurnOn = Random.Range(1, 3);
                switch (randomColorToTurnOn)
                {
                    case 1:
                        if (currentBlue) {
                            futureRed = true;
                        } else {
                            futureBlue = true;
                        }
                        break;
                    case 2:
                        if (currentGreen) {
                            futureBlue = true;
                        } else {
                            futureGreen = true;
                        }
                        break;
                }
                break;
            case 2:
                int randomColorToTurnOff = Random.Range(1, 3);
                futureRed = currentRed;
                futureBlue = currentBlue;
                futureGreen = currentGreen;
                switch (randomColorToTurnOff)
                {
                    case 1:
                        if (currentRed) {
                            futureRed = false;
                        } else if(currentGreen) {
                            futureGreen = false;
                        }
                        break;
                    case 2:
                        if (currentGreen) {
                            futureGreen = false;
                        } else if(currentBlue) {
                            futureBlue = false;
                        }
                        break;
                }
                break;
        }
    }

    void InitializeColor()
    {
        int randomColorToTurnOn = Random.Range(1, 4);
        switch (randomColorToTurnOn)
        {
            case 1:
                currentRed = true;
                break;
            case 2:
                currentGreen = true;
                break;
            case 3:
                currentBlue = true;
                break;
        }
    }

    Color GetCurrentColor()
    {
        return new Color(
            currentRed ? 1 : 0,
            currentGreen ? 1 : 0,
            currentBlue ? 1 : 0
        );
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float relativeTime = Time.time - initialLerpTime;
        bgCamera.backgroundColor = Color.Lerp(fromColor, goalColor, relativeTime / lerpDuration);

        if (relativeTime >= lerpDuration) {
            initialLerpTime = Time.time;
            currentBlue = futureBlue;
            currentRed = futureRed;
            currentGreen = futureGreen;
            fromColor = goalColor;
            MakeFutureColor();
            goalColor = GetFutureColor();
        }
    }
}
