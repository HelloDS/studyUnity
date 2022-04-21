using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /**
     * 飞行速度
     */
    public float Speed = 0.2f;

    /**
     * 飞行时间
     */
    public float Time = 0.02f;
    

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position * Speed * Time;
    }
}
