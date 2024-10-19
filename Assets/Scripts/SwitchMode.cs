using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchMode : MonoBehaviour
{
    public static bool IsAggressor = false;
    private int AggressorCounter;
    [SerializeField] private int MinRange;
    [SerializeField] private int MaxRange;
    [SerializeField] private int AggressorTimeStart;
    private int AggressorTimeRunning;
    private int TimerSpice;
    [SerializeField] public static int Timer;
    [SerializeField] Text timerText;
    [SerializeField] AudioSource Music;


    // Start is called before the first frame update
    void Start()
    {
        AggressorCounter = Random.Range(MinRange, MaxRange);
        Music.volume = .5f;
        Music.pitch = .6f;
        Music.spatialBlend = .75f;
        StartCoroutine("AggressorCountDown");
    }

    private void FixedUpdate()
    {
        if (IsAggressor == true)
        {
            AggressorTimeRunning -= 1;
            if (AggressorTimeRunning % TimerSpice == 0) 
            { 
                Timer -= 1;
                timerText.text = $"Time: {Timer.ToString()}";
                //Debug.Log(Timer);
            }
            if (KillDie.EnemyCount != 0)
            {
                if (AggressorTimeRunning == 0)
                {
                    timerText.text = null;
                    Music.volume = .5f;
                    Music.pitch = .6f;
                    Music.spatialBlend = .75f;
                    IsAggressor = false;
                    //Debug.Log("Passive");
                    StartCoroutine("AggressorCountDown");
                }
            }
            else { timerText.text = null; }
        }
    }

    IEnumerator AggressorCountDown() 
    {
        yield return new WaitForSeconds(AggressorCounter);
        //Debug.Log("Aggressive");
        AggressorCounter = Random.Range(MinRange, MaxRange);
        IsAggressor = true;
        TimerSpice = Random.Range(30, 75);
        AggressorTimeRunning = AggressorTimeStart * TimerSpice;
        Timer = AggressorTimeStart;
        Music.volume = .75f;
        Music.pitch = 1.1f;
        Music.spatialBlend = 1f;
        StopAllCoroutines();
    }
}
