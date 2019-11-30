using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ShieldHealth : MonoBehaviour
{
    #region 血量設定
    public GameObject canvas;
    public Canvas can;
    public float maxHealth;
    [Header("最大血量")]
    public float currentHealth;//血量設定
    public RectTransform HealthBar;
    [Header("Y軸偏移值")]
    public float offsetY = 30f;
    [Header("X軸偏移值")]
    public float offsetX = 0f;
    [Header("跟隨目標")]
    public GameObject Target;//跟隨目標
    [Header("血量")]
    public GameObject Health;//血量
    [Header("血量底圖")]
    public GameObject HealthUnder;//血量底圖

    private float max;//固定長度
    #endregion

    #region 執行
    private void Start()
    {
        canvas = GameObject.Find("Canvas");
        can = canvas.GetComponent<Canvas>();
        maxHealth = gameObject.GetComponent<enemy_satus>().EnemyMaxHp;
        currentHealth = gameObject.GetComponent<enemy_satus>().EnemyHp;
        Health =Instantiate(Resources.Load("血條") as GameObject, can.transform);
        HealthUnder = Instantiate(Resources.Load("血條底圖") as GameObject, can.transform);
        HealthBar = Health.GetComponent<RectTransform>();
        Target = gameObject;
    }

    void Update()
    {
        currentHealth = gameObject.GetComponent<enemy_satus>().EnemyHp;
        HealthBar.sizeDelta = new Vector2(100 * currentHealth / maxHealth, HealthBar.sizeDelta.y);
        Vector2 TargeP = Camera.main.WorldToScreenPoint(Target.transform.position);
        Health.GetComponent<RectTransform>().position = TargeP + Vector2.up * offsetY + Vector2.left * offsetX;
        HealthUnder.GetComponent<RectTransform>().position = TargeP + Vector2.up * offsetY + Vector2.left * offsetX;
       // CleanHpbar();
    }
    #endregion

    /// <summary>
    /// 死掉時清除血條圖案
    /// </summary>
    void CleanHpbar()
    {
        if (currentHealth <= 0)
        {
            Destroy(Health);
            Destroy(HealthUnder);
        }
    }
}