using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{//Subject
    public static event Action onRescuedHostageCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Friendly"))
        {
            onRescuedHostageCount?.Invoke();
            SoundManager.Instance.pointSound.Play();
        }

        if(collision.gameObject.CompareTag("Enemy"))
        {
            SoundManager.Instance.hitSound.Play();
            GameManager.Instance.EndGame();
            //Game Over.
        }
    }
}
