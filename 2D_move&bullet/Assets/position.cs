using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position : MonoBehaviour
   
{
    public Vector3 p;
    public float x;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        p = transform.position;
        x = transform.position.x;
        
     }
}
