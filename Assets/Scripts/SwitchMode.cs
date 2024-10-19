using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMode : MonoBehaviour
{
    public static bool IsAggressor = false;
    private int AggressorCounter;
    [SerializeField] private int MinRange;
    [SerializeField] private int MaxRange;
    [SerializeField] private int AttackMinRange;
    [SerializeField] private int AttackMaxRange;


    // Start is called before the first frame update
    void Start()
    {
        AggressorCounter = Random.Range(MinRange, MaxRange);
        StartCoroutine("AggressorCountDown");
    }

    IEnumerator AggressorCountDown() 
    {
        yield return new WaitForSeconds(AggressorCounter);
        AggressorCounter = Random.Range(AttackMinRange, AttackMaxRange);
        IsAggressor = true;
        yield return new WaitForSeconds(AggressorCounter);
        AggressorCounter = Random.Range(MinRange, MaxRange);
        IsAggressor = true;
    }
}
