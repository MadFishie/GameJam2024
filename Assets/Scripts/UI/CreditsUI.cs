using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsUI : MonoBehaviour
{

	[SerializeField] Canvas mainCanvas;

    // Start is called before the first frame update
    void Start()
    {
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void onBackButton_Pressed()
	{

		Debug.Log("Back Button Pressed");
		mainCanvas.gameObject.SetActive(true);
		gameObject.SetActive(false);
	}
}
