using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_satus : MonoBehaviour
{
    public float EnemyMaxHp;
    public float EnemyHp;
    //1 for fire, 2 for wind ,3 for earth , 4 for ice
    //5 for strong.fire, 6 for strong.wind , 7 for strong.earth , 8 for strong .ice
    public int EnemyElementType;
    // Start is called before the first frame update
    void Start()
    {
        EnemyHp = EnemyMaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHp<=0)
        { Destroy(gameObject); }
    }
}
