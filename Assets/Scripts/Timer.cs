using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Observer ->ScoreManager
     public Text text;
     public bool isCounting;
     public float timer;

    // public static event Action onEnemySlowDown;

    private void Awake()
    {
        ScoreManager.onEnemyKillCount += CountToggle;
        ScoreManager.onEnemySlowDown += Reset;
    }

    private void Start()
    {
        Reset();
    }

    private void Update()
    {
        Count();
    }

    private void Count()
    {
        if (isCounting)
        {
            timer += Time.deltaTime;
            int min = Mathf.FloorToInt(timer / 60f);
            int sec = Mathf.FloorToInt(timer % 60f);
            int mil = Mathf.FloorToInt((timer * 100f) % 100f);
            Display(min, sec, mil);
        }
    }


    private void Display(int min, int sec, int mil)
    {
        text.text = min.ToString("00") + ":" +sec.ToString("00") + ":" + mil.ToString("00");
    }

    public void CountToggle()
    {
        isCounting = !isCounting;
    }


    public void Reset()
    {
        timer = 0;
        isCounting = false;
        text.text = "00:00:00";
    }

}
