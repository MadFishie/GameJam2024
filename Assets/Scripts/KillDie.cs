using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillDie : MonoBehaviour
{ 
    public static int EnemyCount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (SwitchMode.IsAggressor == true)
            {
                Destroy(collision.gameObject);
                EnemyCount -= 1;
            }
            else
            {
                Debug.Log("Died");
            }
        }
    }
}
