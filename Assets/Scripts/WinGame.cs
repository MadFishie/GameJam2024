using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] private GameObject Light;
    [SerializeField] private AudioSource HeartBeat;
    [SerializeField] AudioSource Music;
    private bool CanWin;

    private void Awake()
    {
        HeartBeat.volume = .25f;
        HeartBeat.spatialBlend = 0;
    }
    void FixedUpdate()
    {
        if(KillDie.EnemyCount == 0 && CanWin == false)
        {
            CanWin = true;
            Light.SetActive(true);
            HeartBeat.volume = 1;
            HeartBeat.spatialBlend = 1;
            Music.volume = 0;
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
