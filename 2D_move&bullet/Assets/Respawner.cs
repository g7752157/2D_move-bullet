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
    public int[] LoadLevel,LoadWave,LoadTime,LoadPosition,LoadEnemyType,LoadElement,LoadFinish;
    public int count;
    
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
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
        RespawnReady();
        Respawn();
    }

    void LoadEnemy()
    {
        EnemyList[0] = Resources.Load("Enemy") as GameObject;
        EnemyList[1] = Resources.Load("GroupEnemyFrame") as GameObject;
        EnemyList[2] = Resources.Load("GroundEnemy") as GameObject;
        EnemyList[3] = Resources.Load("ShieldEnemy") as GameObject;

    }

    void RespawnReady()
    {
        
        while (count <= 0)
        {
            for (int i = 0; i < respawn.GetLength(0) ; i++)
            {
                if (respawn[i, 0] == level && respawn[i, 1] == wave)
                {
                    count++;
                    Debug.Log(count);
                }

            }
            LoadRespwn(count);
            int loadnum = 0;
            for (int i = 0; i < respawn.GetLength(0); i++)
            {
                if (respawn[i, 0] == level && respawn[i, 1] == wave)
                {


                    LoadLevel[loadnum] = respawn[i, 0];
                    LoadWave[loadnum] = respawn[i, 1];
                    LoadTime[loadnum] = respawn[i, 2];
                    LoadPosition[loadnum] = respawn[i, 3];
                    LoadEnemyType[loadnum] = respawn[i, 4];
                    LoadElement[loadnum] = respawn[i, 5];
                    LoadFinish[loadnum] = respawn[i, 6];
                    loadnum++;

                }
            }
        }


    }
    void LoadRespwn(int c)
    {
        for (int i = 0; i < c; i++)
        {
            
                LoadLevel = new int[c];
                LoadWave = new int[c];
                LoadTime = new int[c];
                LoadPosition = new int[c];
                LoadEnemyType = new int[c];
                LoadElement = new int[c];
                LoadFinish = new int[c];
                    
        }

        
        
            

        
    }
    void Respawn()
    {
       
        
            for (int i = 0; i < LoadTime.Length; i++)
            {
                if (LoadTime[i]<timer && LoadFinish[i]<=0)
                {
                    
                    Instantiate(EnemyList[LoadEnemyType[i]], pos[LoadPosition[i]], new Quaternion(0,0,0,0));
                    Debug.Log(i);
                    Debug.Log("Respawn!");
                    LoadFinish[i]++;
                    //count--;
                }
            }
        
    }
}
