using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public Vector3[] pos = new Vector3[8];
    public GameObject[] EnemyList = new GameObject[10];
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 up = Vector2.up;
        Vector2 rot =  Quaternion.Euler(0, 0, 30)* up ;
        timer =0;
        LoadEnemy();
        for (int i = 0; i <= 7; i++)
        {
            pos[i]=  gameObject.transform.GetChild(i).gameObject.transform.position;
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    void LoadEnemy()
    {
        EnemyList[0] = Resources.Load("Enemy") as GameObject;
        EnemyList[1] = Resources.Load("GroupEnemyFrame") as GameObject;
        EnemyList[2] = Resources.Load("GroundEnemy") as GameObject;
        EnemyList[3] = Resources.Load("ShieldEnemy") as GameObject;

    }
}
