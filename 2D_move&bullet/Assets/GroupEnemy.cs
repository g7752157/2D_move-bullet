using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupEnemy : MonoBehaviour
{
    public GameObject obj;
    public Vector3 pos1,pos2,pos3,pos4,pos5,pos6;
    //public Vector3[] ChildPosition= { Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero};
    public Vector3[] ChildPosition = new Vector3[6];
    public GameObject[] Childs=new GameObject[6];
    public float BasicRadius = 1;
    public float PeriodScale=200;
    public float RadiusScale;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        //int i = 1;
        timer = 0;
        //create childposition
        for (int i = 1; i <= 6; i++)
        {
         ChildPosition[i-1]= transform.position+Quaternion.Euler(0, 0, 60 * (i - 1)) * (Vector3.up);
        }
        obj = Resources.Load("GroupEnemy") as GameObject;
        //create child
        for (int i = 1; i <= 6; i++)
        {
            
            GameObject child;
            string str;
            child = Instantiate(obj, transform);
            str=i.ToString();
            child.name = str;
            gameObject.transform.GetChild(i - 1).gameObject.transform.position = ChildPosition[i - 1];
            Childs[i - 1] = child;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        //int i = 1;
        int dead = 0;
        timer += Time.deltaTime;
        RadiusScale=0.5f*(2+Mathf.Sin(PeriodScale*timer * Mathf.Deg2Rad));
        for (int i = 1; i <= 6; i++)
        {
            //Debug.Log(i);
            //Debug.Log(transform.position + RadiusScale * (gameObject.transform.GetChild(i - 1).gameObject.transform.position - transform.position));
            if (Childs[i - 1] != null)
            { 
            
            Vector3 pos = Childs[i-1].transform.position;
            Vector3 delta = (pos - transform.position).normalized;
            ChildPosition[i - 1] = transform.position + BasicRadius * RadiusScale *delta ;
            Childs[i - 1].transform.position = ChildPosition[i - 1];
            }
            else
            { dead += 1; }
            
        }

        if (dead >= 6) { Destroy(gameObject); }
    }
}
