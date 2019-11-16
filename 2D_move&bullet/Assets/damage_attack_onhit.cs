using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage_attack_onhit : MonoBehaviour
{
    //把子彈屬性寫在這
    public float timer=0;
    public int BulletAttackForm;
    public int BulletAttackType;
    public int BulletOnHitType;
    public int BulletElementType;
    public float BasicDamage = 1;
    //for debug
    public GameObject Enemy;
    public float EnemyHp;
    public float dmg;
    public int hit = 1;
    public int HitCount = 0;
    //vector for player(fire/wind/earth/ice) , element for Enemy(fire/wind/earth/ice/s.fire/s.wind/s.earth/s.ice)
    public float[,] ElementChart = { {0.5f,1.5f,1,1,0,2,0.75f,0.75f },
                                      {1,0.5f,1.5f,1,0.75f,0,2,0.75f },
                                      {1,1,0.5f,1.5f,0.75f,0.75f,0,2 },
                                      {1.5f,1,1,0.5f,2,0.75f,0.75f,0 } };
    //vector for Form(melee/range), element for Type(swipe,penetrate,bouncing,throwing)
    public float[,] AttackTypeChart = { {1,1,1,1 }, { 0.8f, 1.2f, 0.8f, 3 } };
    //mutiple/ground/explosion
    public float[] OnHitChart = { 0.5f, 0.1f, 0.8f };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //explosion
        if(BulletOnHitType==3 && timer>=0.5)
        { Destroy(gameObject); }
        //multiple
        if (BulletOnHitType == 1)
        {
            if (timer > 0.5)
            {
                hit += 1;
                timer = 0;
            }
            if (hit > 0)
            { gameObject.GetComponent<Collider2D>().enabled = !gameObject.GetComponent<Collider2D>().enabled; }
            if (HitCount >= 3)
            { Destroy(gameObject); }

        }
        //ground
        if (BulletOnHitType == 2)
        {
            if (timer > 0.1)
            {
                hit += 1;
                timer = 0;
            }
            if (hit > 0)
            { gameObject.GetComponent<Collider2D>().enabled = !gameObject.GetComponent<Collider2D>().enabled; }
            if (HitCount >= 15)
            { Destroy(gameObject); }

        }


    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "Enemy")
        {
            //explosion
            if (BulletOnHitType == 3)
            {
                Enemy = col.gameObject;
                EnemyHp = col.GetComponent<enemy_satus>().EnemyHp;
                dmg = BasicDamage * OnHitChart[BulletOnHitType - 1]
                      * ElementChart[BulletElementType - 1, col.GetComponent<enemy_satus>().EnemyElementType - 1];
                col.GetComponent<enemy_satus>().EnemyHp
                    -= BasicDamage * OnHitChart[BulletOnHitType - 1]
                      * ElementChart[BulletElementType - 1, col.GetComponent<enemy_satus>().EnemyElementType - 1];
            }
            //mutiple
            if (BulletOnHitType == 1)
            {
                if (hit > 0)
                {
                    Enemy = col.gameObject;
                    EnemyHp = col.GetComponent<enemy_satus>().EnemyHp;
                    dmg = BasicDamage * OnHitChart[BulletOnHitType - 1]
                          * ElementChart[BulletElementType - 1, col.GetComponent<enemy_satus>().EnemyElementType - 1];
                    col.GetComponent<enemy_satus>().EnemyHp
                    -= BasicDamage * OnHitChart[BulletOnHitType - 1]
                      * ElementChart[BulletElementType - 1, col.GetComponent<enemy_satus>().EnemyElementType - 1];
                    gameObject.transform.eulerAngles += new Vector3(0, 0, 45);
                    gameObject.GetComponent<Collider2D>().enabled = !gameObject.GetComponent<Collider2D>().enabled;
                    hit -= 1;
                    HitCount += 1;
                    if (HitCount >= 3)
                    { Destroy(gameObject); }
                }
            }

           //ground
            if (BulletOnHitType == 2)
            {
                if (hit > 0)
                {
                    Enemy = col.gameObject;
                    EnemyHp = col.GetComponent<enemy_satus>().EnemyHp;
                    dmg = BasicDamage * OnHitChart[BulletOnHitType - 1]
                          * ElementChart[BulletElementType - 1, col.GetComponent<enemy_satus>().EnemyElementType - 1];
                    col.GetComponent<enemy_satus>().EnemyHp
                    -= BasicDamage * OnHitChart[BulletOnHitType - 1]
                      * ElementChart[BulletElementType - 1, col.GetComponent<enemy_satus>().EnemyElementType - 1];
                    gameObject.transform.eulerAngles += new Vector3(0, 0, 45);
                    gameObject.GetComponent<Collider2D>().enabled = !gameObject.GetComponent<Collider2D>().enabled;
                    hit -= 1;
                    HitCount += 1;
                    if (HitCount >= 15)
                    { Destroy(gameObject); }
                }
            }


        }
    }
    
}
