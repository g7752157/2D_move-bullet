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
    public float gravity = 10;
    public float t = 0;
    public Collider2D col;

    //gameObject.GetComponent<velocity>().VelocityScale
    void Start()
    {
        col =gameObject.GetComponent<Collider2D>();
        col.enabled=!col.enabled;
        D = GameObject.Find("character").GetComponent<bullet_shoot>().distance;
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
            if (attacked < 1)
            {
                col.enabled = !col.enabled;
                attacked += 1;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col2)
    {

        if (col2.gameObject.tag == "Enemy" || col2.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}
