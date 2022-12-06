using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]    
    private Gun_Base gun;

    public void RotateLeft()
    {
      transform.rotation = Quaternion.Euler(0f, 0f, 90f);
       gun.Invoker();
    }

    public void RotateRight()
    {
       transform.rotation = Quaternion.Euler(0f,0f,-90f);
        gun.Invoker();
    }

    public void RotateUp()
    {
        transform.rotation = Quaternion.Euler(0f,0f,0f);  
        gun.Invoker();
    }

    public void RotateDown()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        gun.Invoker();
    } 
}
