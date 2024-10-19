using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenus : MonoBehaviour
{

	Canvas creditsCanvas;
	
    // Start is called before the first frame update
    void Start()
    {

		Canvas[] canvasList = FindObjectsByType<Canvas>(FindObjectsSortMode.None);
		foreach(Canvas i in canvasList)
		{

			if(i.name == "CreditsUI")
			{

				creditsCanvas = i;
			}
		}
		Debug.Log(creditsCanvas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void onPlayButton_Pressed()
	{

		Debug.Log("Play Button Pressed");
	}
	public void onCreditsButton_Pressed()
	{
		Debug.Log("Credits Button Pressed");
		
		creditsCanvas.gameObject.SetActive(true);
		gameObject.SetActive(false);
	}
	public void onQuitButton_Pressed()
	{

		Debug.Log("Quit Button Pressed");
	}
}
