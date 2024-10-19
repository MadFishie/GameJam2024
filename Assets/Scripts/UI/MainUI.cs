using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenus : MonoBehaviour
{

	[SerializeField] Canvas creditsCanvas;
	
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
		SceneLoader.loadScenebyName("Scenes/Brett's Fidget Toy");
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
		SceneLoader.QuitGame();
	}
}
