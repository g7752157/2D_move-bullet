using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_shoot : MonoBehaviour
{
    public float m_nextfire;
    // Start is called before the first frame update
    public float firerate = 2.0f;
    public GameObject Bullet;
    public float bulletspeed;
    public float offset_scale;
    public bool shootable = true;
    //1 for swipe , 2 for penatrate , 3 for boundcying, 4 for throwing
    public int AttackType = 4;
    //1 for fire, 2 for wind , 3 for earth , 4 for ice
    //5 for strong.fire, 6 for strong.wind , 7 for strong.earth , 8 for strong .ice
    public int ElementType = 1;
    //mutiple/ground/explosion
    public int OnHitType = 1;
    //1 for melee, 2 for range
    public int AttackForm = 2;
    public float distance = 0;
    
    
    
    
    void Start()
    {
        
    }
    void PrepareShoot()
    {
        m_nextfire = m_nextfire + Time.fixedDeltaTime;
        if (m_nextfire >= firerate)
        {shootable = true;}
        else
        {shootable = false; }
        
    }
    void SingleBulletShot()
    {
        Vector3 m_mouseposition = Input.mousePosition;
        m_mouseposition = Camera.main.ScreenToWorldPoint(m_mouseposition);
        m_mouseposition.z = 0;
        //distance = (m_mouseposition - this.transform.position).magnitude;
        float m_fireangle = Vector2.Angle(m_mouseposition - this.transform.position, Vector2.up);
        if (m_mouseposition.x > this.transform.position.x)
        { m_fireangle = -m_fireangle; }
        Vector3 vec_bullet = (m_mouseposition - this.transform.position).normalized;
        distance = (m_mouseposition - transform.position - offset_scale * vec_bullet).magnitude;
        GameObject m_bullet = Instantiate(Bullet, transform.position + offset_scale * vec_bullet, Quaternion.identity) as GameObject;
        m_bullet.GetComponent<Rigidbody2D>().velocity = vec_bullet * bulletspeed;
        m_bullet.transform.eulerAngles = new Vector3(0, 0, m_fireangle);
    }
    /// <summary>
    /// 3 muti
    /// </summary>
    void MutipleBulletShot3()
    {
        distance = 0;
        Vector3 m_mouseposition = Input.mousePosition;
        m_mouseposition = Camera.main.ScreenToWorldPoint(m_mouseposition);
        m_mouseposition.z = 0;
        //distance = (m_mouseposition - this.transform.position).magnitude;
        float m_fireangle = Vector2.Angle(m_mouseposition - this.transform.position, Vector2.up);
        if (m_mouseposition.x > this.transform.position.x)
        { m_fireangle = -m_fireangle; }
        Vector3 vec_bullet = (m_mouseposition - transform.position).normalized;
        Vector3 vec_bullet2 = (Quaternion.Euler(0, 0, 30) * (m_mouseposition - this.transform.position)).normalized;
        Vector3 vec_bullet3 = (Quaternion.Euler(0, 0, -30) * (m_mouseposition - this.transform.position)).normalized;
        distance = (m_mouseposition - transform.position - offset_scale * vec_bullet).magnitude;

        GameObject m_bullet = Instantiate(Bullet, transform.position + offset_scale * vec_bullet, Quaternion.identity) as GameObject;
        m_bullet.GetComponent<Rigidbody2D>().velocity = vec_bullet * bulletspeed;
        m_bullet.transform.eulerAngles = new Vector3(0, 0, m_fireangle);

        GameObject m_bullet2 = Instantiate(Bullet, transform.position + offset_scale * vec_bullet2, Quaternion.identity) as GameObject;
        m_bullet2.GetComponent<Rigidbody2D>().velocity = vec_bullet2 * bulletspeed;
        m_bullet2.transform.eulerAngles = new Vector3(0, 0, m_fireangle+30);
        
        

        GameObject m_bullet3 = Instantiate(Bullet, transform.position + offset_scale * vec_bullet3, Quaternion.identity) as GameObject;
        m_bullet3.GetComponent<Rigidbody2D>().velocity = vec_bullet3 * bulletspeed;
        m_bullet3.transform.eulerAngles = new Vector3(0, 0, m_fireangle-30);
    }

    void MutipleBulletShot5()
    {
        distance = 0;
        Vector3 m_mouseposition = Input.mousePosition;
        m_mouseposition = Camera.main.ScreenToWorldPoint(m_mouseposition);
        m_mouseposition.z = 0;
        //distance = (m_mouseposition - this.transform.position).magnitude;
        float m_fireangle = Vector2.Angle(m_mouseposition - this.transform.position, Vector2.up);
        if (m_mouseposition.x > this.transform.position.x)
        { m_fireangle = -m_fireangle; }
        Vector3 vec_bullet = (m_mouseposition - transform.position).normalized;
        Vector3 vec_bullet2 = (Quaternion.Euler(0, 0, 30) * (m_mouseposition - this.transform.position)).normalized;
        Vector3 vec_bullet3 = (Quaternion.Euler(0, 0, -30) * (m_mouseposition - this.transform.position)).normalized;
        Vector3 vec_bullet4 = (Quaternion.Euler(0, 0, 60) * (m_mouseposition - this.transform.position)).normalized;
        Vector3 vec_bullet5 = (Quaternion.Euler(0, 0, -60) * (m_mouseposition - this.transform.position)).normalized;

        distance = (m_mouseposition - transform.position - offset_scale * vec_bullet).magnitude;

        GameObject m_bullet = Instantiate(Bullet, transform.position + offset_scale * vec_bullet, Quaternion.identity) as GameObject;
        m_bullet.GetComponent<Rigidbody2D>().velocity = vec_bullet * bulletspeed;
        m_bullet.transform.eulerAngles = new Vector3(0, 0, m_fireangle);

        GameObject m_bullet2 = Instantiate(Bullet, transform.position + offset_scale * vec_bullet2, Quaternion.identity) as GameObject;
        m_bullet2.GetComponent<Rigidbody2D>().velocity = vec_bullet2 * bulletspeed;
        m_bullet2.transform.eulerAngles = new Vector3(0, 0, m_fireangle + 30);

        GameObject m_bullet3 = Instantiate(Bullet, transform.position + offset_scale * vec_bullet3, Quaternion.identity) as GameObject;
        m_bullet3.GetComponent<Rigidbody2D>().velocity = vec_bullet3 * bulletspeed;
        m_bullet3.transform.eulerAngles = new Vector3(0, 0, m_fireangle - 30);

        GameObject m_bullet4 = Instantiate(Bullet, transform.position + offset_scale * vec_bullet4, Quaternion.identity) as GameObject;
        m_bullet4.GetComponent<Rigidbody2D>().velocity = vec_bullet4 * bulletspeed;
        m_bullet4.transform.eulerAngles = new Vector3(0, 0, m_fireangle + 60);

        GameObject m_bullet5 = Instantiate(Bullet, transform.position + offset_scale * vec_bullet5, Quaternion.identity) as GameObject;
        m_bullet5.GetComponent<Rigidbody2D>().velocity = vec_bullet5 * bulletspeed;
        m_bullet5.transform.eulerAngles = new Vector3(0, 0, m_fireangle - 60);


    }
    // Update is called once per frame
    void FixedUpdate()
    {
        PrepareShoot();
        if (shootable == true && Input.GetMouseButton(0))
        {
            if (AttackForm == 2)
            {
                firerate = 1.0f;
                if (AttackType == 1)
                {
                    Bullet = Resources.Load("swipe_bullet", typeof(GameObject)) as GameObject;
                    if (WeaponCheckRange())
                    { MutipleBulletShot3(); m_nextfire = 0;  }
                }
                if (AttackType == 2)
                {
                    Bullet = Resources.Load("penetrate_bullet", typeof(GameObject)) as GameObject;
                    if (WeaponCheckRange())
                    { SingleBulletShot(); m_nextfire = 0;  }
                }
                if (AttackType == 3)
                {
                    Bullet = Resources.Load("bouncing_bullet", typeof(GameObject)) as GameObject;
                    if (WeaponCheckRange())
                    { SingleBulletShot(); m_nextfire = 0;  }
                }
                if (AttackType == 4)
                {
                    Bullet = Resources.Load("throwing_bullet", typeof(GameObject)) as GameObject;
                    if (WeaponCheckRange())
                    { SingleBulletShot(); m_nextfire = 0; ; }
                }
            }
                ///遠程扣武器
                bool WeaponCheckRange()
            {
                if (GetComponent<Character_Status>().characterWeaponRange >= 10)
                {
                    GetComponent<Character_Status>().characterWeaponRange -= 10;
                    return true;
                }
                else
                { return false; }
            }
            if (AttackForm == 1)
            {
                //melee swipe
                if (AttackType == 1)
                {
                    firerate = 0.1f;
                    Bullet = Resources.Load("swipe_melee", typeof(GameObject)) as GameObject;
                    if (WeaponCheckMelee())
                    { MutipleBulletShot5(); m_nextfire = 0; }
                }
                //melee penetrate
                if (AttackType == 2)
                {
                    firerate = 0.5f;
                    Bullet = Resources.Load("penetrate_melee", typeof(GameObject)) as GameObject;
                    if (WeaponCheckMelee())
                    { SingleBulletShot(); m_nextfire = 0; }
                }

                //melee bouncing
                if (AttackType == 3)
                {
                    firerate = 0.1f;
                    Bullet = Resources.Load("bouncing_melee", typeof(GameObject)) as GameObject;
                    if (WeaponCheckMelee())
                    { SingleBulletShot(); m_nextfire = 0; }
                }

                //melee throw
                if (AttackType == 4)
                {
                    firerate = 0.1f;
                    Bullet = Resources.Load("throwing_melee", typeof(GameObject)) as GameObject;
                    if (WeaponCheckMelee())
                    { SingleBulletShot(); m_nextfire = 0; }
                }
                ///進戰扣武器
                bool WeaponCheckMelee()
                {
                    if (GetComponent<Character_Status>().characterWeaponMelee >= 10)
                    {
                        GetComponent<Character_Status>().characterWeaponMelee -= 10;
                        return true;
                    }
                    else
                    { return false; }
                }

            }

        }
    }
}
