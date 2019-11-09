using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag=="Bullet")
        {
            GameObject obj = col.gameObject;
            if (obj.GetComponent<damage_attack_type>().BulletAttackType != 2)
            { Destroy(obj); }
        }
    }
}
