using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float countDown;
    public float maxDuration = 40.0f;
    public static bool isGameOver = false;

    public float hungerUpdateTime = 0f;
    float currentHungerTime;
    public int hunger = 100;

    public Text timerText;
    public Text hungerText;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        countDown = maxDuration;

        SetTimeText();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
                SetTimeText();
                currentHungerTime = Time.time;

                if (currentHungerTime - hungerUpdateTime > 30.0f)
                {
                    hunger -= 5;
                    hungerUpdateTime = currentHungerTime;
                }
                hungerText.text = hunger.ToString("0");

            } else
            {
                LevelLost();
            }
        }
    }

    void SetTimeText()
    {
        timerText.text = countDown.ToString("0.00");
    }

    void SetHungerText()
    {
        hungerText.text = hunger.ToString("0");
    }

    void LevelLost()
    {
        isGameOver = true;

    }
}
