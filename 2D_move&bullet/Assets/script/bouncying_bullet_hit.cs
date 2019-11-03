using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncying_bullet_hit : MonoBehaviour
{

    public float BulletLife;
    public Collider2D[] cols;
    //public Collider2D LastHitEnemy;
    public string LastHitEnemyName = null;
    public Vector3 lastposition;
    public float MoveDistance;
    public float form;
    

    // Start is called before the first frame update


    void Start()
    {
        form = gameObject.GetComponent<damage_attack_type>().BulletAttackForm;
        MoveDistance = 0;
        lastposition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveDistance += (gameObject.transform.position - lastposition).magnitude;
        if (form == 1) { if (MoveDistance > 1) { Destroy(gameObject); } }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
        Transform OnGetEmemy()
        {
            int radius = 1;
            while (radius < 10000)
            {
                

                cols = Physics2D.OverlapCircleAll(transform.position, radius);
                if (cols.Length > 0)
                {
                    for (int i = 0; i < cols.Length; i++)
                    {
                        if (cols[i].tag == "Enemy")
                        {
                            if (cols[i].name != col.name)
                            {
                                if (cols[i].name != LastHitEnemyName)
                                {
                                    Transform t = cols[i].transform;
                                    return t;
                                }
                            }
                        }
                    }
                }
                radius += 1;

            }
            //destroy if no target
            Destroy(gameObject);
            
            return transform;
        }
        Transform EnemyPosition = OnGetEmemy();

        Vector2 BouncingDirection=new Vector2  (EnemyPosition.position.x - transform.position.x, EnemyPosition.position.y - transform.position.y);
        gameObject.GetComponent<Rigidbody2D>().velocity = BouncingDirection.normalized;
        if(col.gameObject.tag == "Enemy" )
        {

            BulletLife -= 1;
            MoveDistance = 0;
        }
        if (BulletLife <= 0)
        { Destroy(this.gameObject); }
        
    }
    void OnTriggerExit2D(Collider2D col)
    {
        LastHitEnemyName = col.name;
    }


}
