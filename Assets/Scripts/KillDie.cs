using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillDie : MonoBehaviour
{ 
    public static int EnemyCount;
    private bool HitCheck = false;
    [SerializeField] private int EnemyCountSetup;
    private void Awake()
    {
        EnemyCount = EnemyCountSetup;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && HitCheck == false)
        {
            HitCheck = true;
            if (SwitchMode.IsAggressor == true)
            {
                Destroy(collision.gameObject);
                EnemyCount -= 1;
                Debug.Log(EnemyCount);
            }
            else
            {
                //Debug.Log("Died");
                SceneLoader.loadScenebyName("Menu_Lose");
            }
        }
    }
    private void Update()
    {
        HitCheck = false;
    }
}
