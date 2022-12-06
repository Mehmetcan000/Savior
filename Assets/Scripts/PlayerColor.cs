using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerColor : MonoBehaviour
{
    SpriteRenderer playerSpriteRenderer;
    [SerializeField]
    private SpriteRenderer gunSpriteRenderer;

    private void Awake()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {

        ScoreManager.onEnemyKillCount += EventRandomColor;
        ScoreManager.onEnemySlowDown += EventMainColor;
    }

    private void OnDisable()
    {
        ScoreManager.onEnemyKillCount -= EventRandomColor;
        ScoreManager.onEnemySlowDown -= EventMainColor;

    }

    public void EventRandomColor()
    {
        playerSpriteRenderer.DOColor(Random.ColorHSV(), 1f);
        gunSpriteRenderer.DOColor(Random.ColorHSV(), 1f);
    }

    public void EventMainColor()
    {
        playerSpriteRenderer.DOColor(Color.black, 1f);
        gunSpriteRenderer.DOColor(Color.yellow, 1f);
    }

}
