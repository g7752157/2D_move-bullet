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
    public double BasicDamage = 1;
    public GameObject OnHit;
    [Header("上一步位置")]
    public Vector3 LastPosition;
    public float MovedDistance;
    public Vector3 char_to_bullet;
    public float timer;
    public Collider2D col;
    
    //vector for player(fire/wind/earth/ice) , element for Enemy(fire/wind/earth/ice/s.fire/s.wind/s.earth/s.ice)
    public double[,] ElementChart = { {0.5,1.5,1,1,0,2,0.75,0.75 },
                                      {1,0.5,1.5,1,0.75,0,2,0.75 },
                                      {1,1,0.5,1.5,0.75,0.75,0,2 },
                                      {1.5,1,1,0.5,2,0.75,0.75,0 } };
    //vector for Form(melee/range), element for Type(swipe,penetrate,bouncing,throwing)
    public double[,] AttackTypeChart = { {1,1,1,1 }, { 0.8, 1.2, 0.8, 3 } };
    //mutiple/ground/explosion
    public double[] OnHitChart = { 0.5, 0.5, 0.8 };
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
    }
}
