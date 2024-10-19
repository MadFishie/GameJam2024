using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

	double realTime = 0.00;
	int timeSec = 0;

	[SerializeField] Text timerText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		realTime += Time.deltaTime;
		timeSec = Mathf.RoundToInt((float)(realTime % 60));

		timerText.text = $"Time: {timeSec.ToString()}";
	}
}
