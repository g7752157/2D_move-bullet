using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class do_damage_to_enemy : MonoBehaviour
{
    public float enemy_hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
       
        if (col.tag == "Penetrate_Bullet")
        {
            enemy_hp -= 1;
            if (enemy_hp == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            enemy_hp -= 1;
            if (enemy_hp == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
