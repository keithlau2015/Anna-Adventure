using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour    
{
	public string GameLevel;
	public void switchscene(string LevelToLoad)//For other scene go back to the Meun
	{
			//Animation of Mr. Fish jumping out and create a portol to go back to the main meun
			SceneManager.LoadScene(LevelToLoad);
	}
	private void OnTriggerEnter2D(Collider2D player)
	{
		if (player.CompareTag ("Player")) {
			SceneManager.LoadScene (GameLevel);
		}
	}
}
