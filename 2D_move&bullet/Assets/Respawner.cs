using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public Vector3[] pos = new Vector3[8];
    public GameObject[] EnemyList = new GameObject[10];
    public float timer;
    public int wave, level;
    //level-wave-time-positon-enemy-element-fin
    public int[,] respawn = { { 1,1,5,0,0,0,0},{ 1,1,10,3,0,0,0} };
    public int[] LoadLevel,LoadWave,LoadTime,LoadPosition,LoadEnemy,LoadElement,LoadFinish;
    
    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
        level = 1;
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

    void Respawn(int level, int wave)
    {
       for(int i=0;i<respawn.GetLength(0)-1 ;i++  )
        {
            
        }
       
    }
}
