using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{   //Observer  ->  Player.
    //Subject -> Audio Manager , SpawnManager , Timer.

    public Timer timer;

    public int score;
    public int enemyKillScore;
    public int rescuedHostageScore;
    public Text scoreText;
    public Text rescuedHostageText;
    public Text enemyKillText;

    public static event Action onEnemyKillCount;
    public static event Action onEnemySlowDown;


    private void Awake()
    {
        scoreText.text = score.ToString();
    
    }

    private void OnEnable()
    {
        Bullet.onEnemyKillCountChanged += KillScore;
        PlayerCollision.onRescuedHostageCount += RescuedHostage;
    }

    private void OnDisable()
    {
        Bullet.onEnemyKillCountChanged -= KillScore;
        PlayerCollision.onRescuedHostageCount -= RescuedHostage;
    }

    void Start()
    {
        score = 0;
        enemyKillScore = 0;
        rescuedHostageScore = 0;
    }

    private void Update()
    {
        Scored();
        DangerZoneExit();
    }

    public void DangerZoneExit()
    {
        if (timer.timer>=8)
        {
            Debug.Log("Danger zone dan çýkýþ yapýlýyor!");
            onEnemySlowDown?.Invoke();
        }
    }

    public void KillScore()
    {
        enemyKillScore++;
        if (enemyKillScore % 6 == 0)
        {
            onEnemyKillCount?.Invoke();
        }
        enemyKillText.text = enemyKillScore.ToString();
    }
    
    public void RescuedHostage()
    {
        rescuedHostageScore++;
        rescuedHostageText.text = rescuedHostageScore.ToString();
    }
    public void Scored()
    {
        score = rescuedHostageScore * enemyKillScore;
        scoreText.text = score.ToString();
    }
}
