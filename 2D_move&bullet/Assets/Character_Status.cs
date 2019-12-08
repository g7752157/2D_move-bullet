using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Status : MonoBehaviour
{
    #region [欄位]
    [Range(0,100)]
    public float characterHP,characterWeaponRange, characterWeaponMelee, CharacterRUNE,hittenDmg,hittableTimer, InvincibleTime, spriteTimer = 0;

    public bool isHit,hittable;


    #endregion
    // Start is called before the first frame update
    void Start()
    {
        InvincibleTime = 1;
        hittableTimer = 0;
        hittenDmg = 10;
        characterHP = 100;
        characterWeaponMelee = 100;
        characterWeaponRange = 100;
        CharacterRUNE = 0;
        isHit = false;
        hittable = true;
    }

    // Update is called once per frame
    void Update()
    {
        hittableTimer += Time.deltaTime;
        Hitten();
    }

    #region [方法]
    void Hitten()
    {
        
        
        spriteTimer += Time.deltaTime;
        if (isHit == true )
        {
            hittable = false;
            hittableTimer=0;
            characterHP -= hittenDmg;
            isHit = false;
        }

        if(hittable==false&&hittableTimer>InvincibleTime)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            hittable = true;
            spriteTimer = 0;
        }

        if(hittable==false && hittableTimer<= InvincibleTime && spriteTimer>0.1)
        {
            GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
            Debug.Log("switch!");
            spriteTimer = 0;
        }
        
    }

    #endregion
}
