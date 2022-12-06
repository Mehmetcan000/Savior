using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource pointSound , playSound,hitSound;

    private void Awake()
    {
        if (Instance == null)//Singleton
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Farklý sahnelerde bu sayede kullanabileceðiz.

        }
        else
        {
            Destroy(gameObject);
        }

       
    }

    private void OnEnable()
    {
        ScoreManager.onEnemyKillCount += SoundAcceleration;
        ScoreManager.onEnemySlowDown += SoundSlowDown;

    }

    private void OnDisable()
    {
        ScoreManager.onEnemyKillCount -= SoundAcceleration;
        ScoreManager.onEnemySlowDown -= SoundSlowDown;
    }

    private void SoundAcceleration()
    {
        playSound.pitch = 1.15f;
        playSound.volume = .7f;
    }

    private void SoundSlowDown()
    {
        playSound.pitch = 1f;
        playSound.volume = .5f;
    }
}
