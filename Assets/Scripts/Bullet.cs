using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;


    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y > gv.core.cameraController.screenBoundTop)
        {
            Destroy(gameObject);
        }
    }
}
