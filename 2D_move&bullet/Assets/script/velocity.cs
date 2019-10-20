using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocity : MonoBehaviour
{
    // Start is called before the first frame update
    public float VelocityScale;
    Rigidbody2D RigibodyBullet;
    void Start()
    {
        RigibodyBullet = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RigibodyBullet.velocity = VelocityScale*RigibodyBullet.velocity.normalized;
    }
}
