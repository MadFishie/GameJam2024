using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenus : MonoBehaviour
{
	
    // Start is called before the first frame update
    void Start()
    {
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
	}
	public void onQuitButton_Pressed()
	{

		Debug.Log("Quit Button Pressed");
	}
}
