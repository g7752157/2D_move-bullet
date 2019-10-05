using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_shoot : MonoBehaviour
{
    private float m_nextfire;
    // Start is called before the first frame update
    public float firerate = 2.0f;
    public GameObject Bullet;
    public GameObject NormalBullet;
    public GameObject SwipeBullet;
    public GameObject PanetrateBullet;
    public GameObject BouncyingBullet;
    public float bulletspeed;
    public float offset_scale;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_nextfire = m_nextfire + Time.fixedDeltaTime;
        if(Input.GetMouseButton(0) && m_nextfire >= firerate)
        {
            Vector3 m_mouseposition = Input.mousePosition;
            m_mouseposition = Camera.main.ScreenToWorldPoint(m_mouseposition);
            m_mouseposition.z = 0;
            float m_fireangle = Vector2.Angle(m_mouseposition - this.transform.position, Vector2.up);
            if(m_mouseposition.x>this.transform.position.x)
            {
                m_fireangle = -m_fireangle;
            }
            Vector3 vec_bullet = (m_mouseposition - this.transform.position).normalized;
            Vector3 vec_bullet2 = (Quaternion.Euler(0,0,20)*(m_mouseposition - this.transform.position)).normalized;
            Vector3 vec_bullet3 = (Quaternion.Euler(0, 0, -20) * (m_mouseposition - this.transform.position)).normalized;
            m_nextfire = 0;

            GameObject m_bullet = Instantiate(Bullet, transform.position + offset_scale*vec_bullet, Quaternion.identity) as GameObject;
            m_bullet.GetComponent<Rigidbody2D>().velocity = vec_bullet * bulletspeed;
            m_bullet.transform.eulerAngles = new Vector3(0, 0, m_fireangle);

            GameObject m_bullet2 = Instantiate(Bullet, transform.position + offset_scale * vec_bullet2, Quaternion.identity) as GameObject;
            m_bullet2.GetComponent<Rigidbody2D>().velocity = vec_bullet2 * bulletspeed;
            m_bullet2.transform.eulerAngles = new Vector3(0, 0, m_fireangle);

            GameObject m_bullet3 = Instantiate(Bullet, transform.position + offset_scale * vec_bullet3, Quaternion.identity) as GameObject;
            m_bullet3.GetComponent<Rigidbody2D>().velocity = vec_bullet3 * bulletspeed;
            m_bullet3.transform.eulerAngles = new Vector3(0, 0, m_fireangle);
        }
    }
}
