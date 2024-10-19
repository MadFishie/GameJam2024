using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // Start is called before the first frame update
    void Start()
    {
        AggressorCounter = Random.Range(MinRange, MaxRange);
        StartCoroutine("AggressorCountDown");
    }

    private void FixedUpdate()
    {
        if (IsAggressor == true)
        {
            AggressorTimeRunning -= TimerSpice;
            if (AggressorTimeRunning % TimerSpice == 0) { Timer -= 1; }
            if (AggressorTimeRunning == 0)
            {
                IsAggressor = false;
                StartCoroutine("AggressorCountDown");
            }
        }
    }

    IEnumerator AggressorCountDown() 
    {
        yield return new WaitForSeconds(AggressorCounter);
        AggressorCounter = Random.Range(MinRange, MaxRange);
        IsAggressor = true;
        TimerSpice = Random.Range(30, 75);
        AggressorTimeRunning = AggressorTimeStart * TimerSpice;
        StopAllCoroutines();
    }
}
