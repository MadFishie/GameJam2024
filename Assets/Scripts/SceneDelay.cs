using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDelay : MonoBehaviour
{
    [SerializeField] private int WaitTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CountDown");
    }
    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(WaitTime);
        //add scene loader here
        Debug.Log("main menu");

    }


}
