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
            AggressorTimeRunning -= 1;
            if (AggressorTimeRunning % TimerSpice == 0) 
            { 
                Timer -= 1;
                timerText.text = $"Time: {Timer.ToString()}";
                Debug.Log(Timer);
            }
            if (AggressorTimeRunning == 0)
            {
                IsAggressor = false;
                Debug.Log("Passive");
                StartCoroutine("AggressorCountDown");
            }
        }
    }

    IEnumerator AggressorCountDown() 
    {
        yield return new WaitForSeconds(AggressorCounter);
        Debug.Log("Aggressive");
        AggressorCounter = Random.Range(MinRange, MaxRange);
        IsAggressor = true;
        TimerSpice = Random.Range(30, 75);
        AggressorTimeRunning = AggressorTimeStart * TimerSpice;
        Timer = AggressorTimeStart;
        StopAllCoroutines();
    }
}
