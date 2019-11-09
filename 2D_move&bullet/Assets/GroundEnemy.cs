using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    public bool InGround;
    // Start is called before the first frame update
    void Start()
    {
        InGround = true;
        gameObject.tag = "GroundEnemy";
    }

    // Update is called once per frame
    void Update()
    {
        if (InGround == true) { gameObject.tag = "GroundEnemy"; }
        if (InGround == false) { gameObject.tag = "Enemy"; }
    }
}
