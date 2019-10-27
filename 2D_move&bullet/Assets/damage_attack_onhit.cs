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
    public double BasicDamage = 1;
    //for debug
    public GameObject Enemy;
    public double EnemyHp;
    public double dmg;
    public int hit = 1;
    public int HitCount = 0;
    //vector for player(fire/wind/earth/ice) , element for Enemy(fire/wind/earth/ice/s.fire/s.wind/s.earth/s.ice)
    public double[,] ElementChart = { {0.5,1.5,1,1,0,2,0.75,0.75 },
                                      {1,0.5,1.5,1,0.75,0,2,0.75 },
                                      {1,1,0.5,1.5,0.75,0.75,0,2 },
                                      {1.5,1,1,0.5,2,0.75,0.75,0 } };
    //vector for Form(melee/range), element for Type(swipe,penetrate,bouncing,throwing)
    public double[,] AttackTypeChart = { {1,1,1,1 }, { 0.8, 1.2, 0.8, 3 } };
    //mutiple/ground/explosion
    public double[] OnHitChart = { 0.5, 0.1, 0.8 };
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
