﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D col2)
    {

        if (col2.gameObject.tag == "Bullet")
        {
            Destroy(col2.gameObject);
        }
    }
}
