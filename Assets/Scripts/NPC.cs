using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NPC : MonoBehaviour, IMove , IDamageable
{

 
    public float duration;
    public float turn;
    void Start()
    {
        Move();
        Rotate();
    }

    public void Rotate()
    {
        //transform.DORotate(new Vector3(0, 0, -180), turn).SetLoops(-1, LoopType.Incremental);
    }

    public void Move()
    {
        transform.DOMove(new Vector3(0, 0, 0), duration);
    }

    public void GetDamage()
    {
        gameObject.SetActive(false);  
    }
}

public interface IMove
{
    public void Move();
}

public interface IDamageable
{
    public void GetDamage();
}