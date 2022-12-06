using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{//Subject

    public static event Action onEnemyKillCountChanged;
    
    public float bulletSpeed;
  
    private void OnEnable()
    {
        Invoke("Disable", 2f);
    }
    private void Update()
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("dawdaw");
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Friendly"))
        { 
            collision.gameObject.GetComponent<IDamageable>().GetDamage();
            Disable();
        }

        if(collision.gameObject.CompareTag("Enemy"))
        {
            onEnemyKillCountChanged?.Invoke();
            SoundManager.Instance.pointSound.Play();
        }
        if (collision.gameObject.CompareTag("Friendly"))
        {
            GameManager.Instance.EndGame();
          //Game Over. 
            SoundManager.Instance.hitSound.Play();
        }
    }
}
