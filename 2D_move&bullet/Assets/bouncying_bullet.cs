using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncying_bullet : MonoBehaviour
{
    public float BulletLife;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {

            BulletLife -= 1;
        }
        if (BulletLife <= 0)
        { Destroy(this.gameObject); }
    }
}
