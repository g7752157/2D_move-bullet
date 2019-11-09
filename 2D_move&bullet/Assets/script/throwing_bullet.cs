using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwing_bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float attacked = 0;
    public double height = 0;
    public float D;
    public float LifeTime = 100;
    public float Vy = 15;
    public float gravity;
    public float t = 0;
    public int form;

    //gameObject.GetComponent<velocity>().VelocityScale
    void Start()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        form = gameObject.GetComponent<damage_attack_type>().BulletAttackForm;
        if (form == 1) { gravity = 50.0f; }
        if (form == 2) { gravity = 25.0f; }
        D = GameObject.Find("character").GetComponent<bullet_shoot>().distance;
        if (form == 1)
        {
            if (D >= 1) { D = 1f; }
        }
        LifeTime = 2*Vy/gravity;
        gameObject.GetComponent<velocity>().VelocityScale = D / LifeTime;

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        height = Vy * t - 0.5 * gravity * t * t;
        if (height<0)
        {
                gameObject.GetComponent<Collider2D>().enabled = true;
        }
        if (height < -0.5) { Destroy(gameObject); }
    }
    void OnTriggerEnter2D(Collider2D col2)
    {

        if (col2.gameObject.tag == "Enemy" || col2.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}
