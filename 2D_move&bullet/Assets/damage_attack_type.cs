using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage_attack_type : MonoBehaviour
{
    //把子彈屬性寫在這
    public int BulletAttackForm;
    public int BulletAttackType;
    public int BulletOnHitType;
    public int BulletElementType;
    public float BasicDamage = 1;
    public GameObject OnHit;
    [Header("上一步位置")]
    public Vector3 LastPosition;
    public float MovedDistance;
    public Vector3 char_to_bullet;
    public float timer;
    public Collider2D col;
    
    //vector for player(fire/wind/earth/ice) , element for Enemy(fire/wind/earth/ice/s.fire/s.wind/s.earth/s.ice)
    public float[,] ElementChart = { {0.5f,1.5f,1,1,0,2,0.75f,0.75f },
                                      {1,0.5f,1.5f,1,0.75f,0,2,0.75f },
                                      {1,1,0.5f,1.5f,0.75f,0.75f,0,2 },
                                      {1.5f,1,1,0.5f,2,0.75f,0.75f,0 } };
    //vector for Form(melee/range), element for Type(swipe,penetrate,bouncing,throwing)
    public float[,] AttackTypeChart = { {1,1,1,1 }, { 0.8f, 1.2f, 0.8f, 3 } };
    //mutiple/ground/explosion
    public float[] OnHitChart = { 0.5f, 0.5f, 0.8f };
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        col.enabled = false;
        timer = 0;
        BulletAttackType = GameObject.Find("character").GetComponent<bullet_shoot>().AttackType;
        BulletElementType = GameObject.Find("character").GetComponent<bullet_shoot>().ElementType;
        BulletAttackForm = GameObject.Find("character").GetComponent<bullet_shoot>().AttackForm;
        BulletOnHitType = GameObject.Find("character").GetComponent<bullet_shoot>().OnHitType;
        LastPosition = transform.position;
        MovedDistance = 0;
        char_to_bullet=transform.position-GameObject.Find("character").GetComponent<Transform>().position;
        if (BulletAttackType != 4)
        { col.enabled = true; }

    }

    // Update is called once per frame
    void Update()
    {
        //timer
        timer += Time.deltaTime;
        //move distance
        MovedDistance += (transform.position - LastPosition).magnitude;
        LastPosition = transform.position;
        //melee bullet destroy when > distance
        if (BulletAttackForm == 1 )
        {
            if(BulletAttackType==1)
            { if (MovedDistance > 1) { Destroy(gameObject); } }
        }
        //melee penetrate
        if (BulletAttackForm == 1)
        {
            float SwitchTimer=0.1f;
            float DestroyTimer = 2.0f;
            float SlowVelocity=0.1f;
            float FastVelocity = 10.0f;
            
            if (BulletAttackType == 2)
            { if (timer < SwitchTimer)
                {
                    GetComponent<Rigidbody2D>().velocity=SlowVelocity* GetComponent<Rigidbody2D>().velocity.normalized;
                    transform.position = GameObject.Find("character").GetComponent<Transform>().position + char_to_bullet;
                }
            
            

                if (timer > SwitchTimer)
                { GetComponent<Rigidbody2D>().velocity = FastVelocity * GetComponent<Rigidbody2D>().velocity.normalized; }
                if (timer > DestroyTimer) { Destroy(gameObject); }

                
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //Damaging
        if (col.tag == "Enemy")
        {
            col.GetComponent<enemy_satus>().EnemyHp 
                -= BasicDamage * AttackTypeChart[ BulletAttackForm-1  , BulletAttackType-1]
                  *ElementChart[BulletElementType-1,col.GetComponent<enemy_satus>().EnemyElementType-1];
        }
        if (col.tag == "GroundEnemy" & BulletAttackType == 4)
        {
            col.GetComponent<enemy_satus>().EnemyHp
                -= BasicDamage * AttackTypeChart[BulletAttackForm - 1, BulletAttackType - 1]
                  * ElementChart[BulletElementType - 1, col.GetComponent<enemy_satus>().EnemyElementType - 1];
        }
        //OnHitting
        if (col.tag == "Enemy")
        {
            if (BulletOnHitType == 3)//for explosion
            {
                OnHit = Instantiate(Resources.Load("explosion"), gameObject.transform.position, Quaternion.identity) as GameObject;
                OnHit.GetComponent<damage_attack_onhit>().BulletOnHitType = BulletOnHitType;
                OnHit.GetComponent<damage_attack_onhit>().BulletElementType = BulletElementType;

            }
            if (BulletOnHitType == 1)//for mutiple
            {
                OnHit = Instantiate(Resources.Load("mutiple"), gameObject.transform.position, Quaternion.identity) as GameObject;
                OnHit.GetComponent<damage_attack_onhit>().BulletOnHitType = BulletOnHitType;
                OnHit.GetComponent<damage_attack_onhit>().BulletElementType = BulletElementType;
            }
            if (BulletOnHitType == 2)//for ground
            {
                    OnHit = Instantiate(Resources.Load("ground"), gameObject.transform.position, Quaternion.identity) as GameObject;
                    OnHit.GetComponent<damage_attack_onhit>().BulletOnHitType = BulletOnHitType;
                    OnHit.GetComponent<damage_attack_onhit>().BulletElementType = BulletElementType;
            }

        }
        if (col.tag == "GroundEnemy" & BulletAttackType == 4)
        {
            if (BulletOnHitType == 3)//for explosion
            {
                OnHit = Instantiate(Resources.Load("explosion"), gameObject.transform.position, Quaternion.identity) as GameObject;
                OnHit.GetComponent<damage_attack_onhit>().BulletOnHitType = BulletOnHitType;
                OnHit.GetComponent<damage_attack_onhit>().BulletElementType = BulletElementType;

            }
            if (BulletOnHitType == 1)//for mutiple
            {
                OnHit = Instantiate(Resources.Load("mutiple"), gameObject.transform.position, Quaternion.identity) as GameObject;
                OnHit.GetComponent<damage_attack_onhit>().BulletOnHitType = BulletOnHitType;
                OnHit.GetComponent<damage_attack_onhit>().BulletElementType = BulletElementType;
            }
            if (BulletOnHitType == 2)//for ground
            {
                OnHit = Instantiate(Resources.Load("ground"), gameObject.transform.position, Quaternion.identity) as GameObject;
                OnHit.GetComponent<damage_attack_onhit>().BulletOnHitType = BulletOnHitType;
                OnHit.GetComponent<damage_attack_onhit>().BulletElementType = BulletElementType;
            }
        }
    }
}
