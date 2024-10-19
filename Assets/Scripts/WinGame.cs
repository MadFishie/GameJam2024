using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] private GameObject Light;
    [SerializeField] private GameObject HeartBeat;
    private bool CanWin;

    void FixedUpdate()
    {
        if(KillDie.EnemyCount == 0 && CanWin == false)
        {
            CanWin = true;
            Light.SetActive(true);
            HeartBeat.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //put win scene loader here!
        }
    }
}
