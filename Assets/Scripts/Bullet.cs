using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public bool MoveRight;
    void Start()
    {
        
    }

    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(1 * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
        }
    }
}
