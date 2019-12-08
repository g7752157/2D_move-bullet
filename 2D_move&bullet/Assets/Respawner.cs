using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public Vector3[] pos = new Vector3[8];
    public GameObject back;
    public GameObject[] EnemyList = new GameObject[10];
    public float timer;
    public int wave, level;
    //level-wave-time-positon-enemy-element-fin
    public int[,] respawn = { 
        { 1,1,1,0,0,2,0},
        { 1,2,3,3,0,3,0}, 
        { 2,1,0,0,0,0,0 },{ 2,1,0,0,0,0,0 },{ 2,1,2,3,0,0,0 },{ 2,1,2,3,0,0,0 },{ 2,1,5,6,0,0,0 } };
    public int[] LoadLevel,LoadWave,LoadTime,LoadPosition,LoadEnemyType,LoadElement,LoadFinish;
    public GameObject[] AllEnemy;
    public int count;
    public int EnemyCount;
    public bool countable;
    
    // Start is called before the first frame update
    void Start()
    {
        countable = true;
        count = 0;
        EnemyCount = 0;
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
        Debug.Log("EnemyCount = " + WaveEnemyCount(AllEnemy));
        if (WaveEnemyCount(AllEnemy) == 0) { SwitchWave(); };
        BackGroundMove(back);
        
    }

    void LoadEnemy()
    {
        EnemyList[0] = Resources.Load("Enemy") as GameObject;
        EnemyList[1] = Resources.Load("GroupEnemyFrame") as GameObject;
        EnemyList[2] = Resources.Load("GroundEnemy") as GameObject;
        EnemyList[3] = Resources.Load("ShieldEnemy") as GameObject;

    }
    /// <summary>
    /// 數一波敵人有幾隻，然後記錄到各個Load矩陣裡面
    /// </summary>
    void RespawnReady()
    {
        
        if (countable == true)
        {
            for (int i = 0; i < respawn.GetLength(0) ; i++)
            {
                if (respawn[i, 0] == level && respawn[i, 1] == wave)
                {
                    count++;
                    
                }

            }
            if (count == 0) { SwitchLevel(); return; }
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
                    Debug.Log("loadnum =" + loadnum);

                }
            }
            
        }
        countable = false;

    }
    /// <summary>
    /// 生成Load陣列
    /// </summary>
    /// <param name="c"></param>
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
                AllEnemy = new GameObject[c];


        }

        
        
            

        
    }
    /// <summary>
    /// 在該波正確時間點由LOAD陣列裡面讀取並生成敵人
    /// </summary>
    void Respawn()
    {
       
        
            for (int i = 0; i < LoadTime.Length; i++)
            {
                if (LoadTime[i]<timer && LoadFinish[i]<=0)
                {
                    
                    AllEnemy[i]=Instantiate(EnemyList[LoadEnemyType[i]], pos[LoadPosition[i]], new Quaternion(0,0,0,0));
                    AllEnemy[i].GetComponent<enemy_satus>().EnemyElementType = LoadElement[i]+1;
                    Debug.Log(i);
                    Debug.Log("Respawn!");
                    LoadFinish[i]++;
                    count--;
                }
            }
        
    }
    /// <summary>
    /// 換波換關
    /// </summary>
    void SwitchWave()
    {
        wave += 1;
        timer = 0;
        CleanLoad();
        countable = true;
        Debug.Log("Switch!");
    }
    void SwitchLevel()
    {
        wave = 1;
        level += 1;
        timer = 0;
        CleanLoad();
        countable = true;
        Debug.Log("Switch!");
    }

    /// <summary>
    /// 清空Load
    /// </summary>
    void CleanLoad()
    {
        LoadLevel = new int[0];
        LoadWave = new int[0];
        LoadTime = new int[0];
        LoadPosition = new int[0];
        LoadEnemyType = new int[0];
        LoadElement = new int[0];
        LoadFinish = new int[0];
    }
    int WaveEnemyCount(GameObject[] list)
    {
        
        if (countable == false && timer>LoadTime[0])
        {
            int c=0;
            for(int i=0; i< list.Length; i++)
            {
                if (list[i] != null) { c++; }
            }
            return c;
        }
        return 100;
    }

    void BackGroundMove(GameObject back)
    {
        back = GameObject.Find("background");

        back.transform.position = Vector3.MoveTowards(new Vector3(0, -10*(level-2), 0),  new Vector3(0, -10*(level-1), 0), 10);
    }
}
