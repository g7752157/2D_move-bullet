using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipe_bullet_hit : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col2)
    {

        if (col2.gameObject.tag == "Enemy" || col2.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
