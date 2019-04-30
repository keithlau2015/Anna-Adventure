using System;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
	public bool Checkpause = false;
	public GameObject pauseScene;
		
	void Update()
	{
		SettingUI();
	}

	public void Pause()
	{
		pauseScene.SetActive (true);
		Time.timeScale = 0.1f;
		Checkpause = true;
	}

	public void Resume()
	{
		pauseScene.SetActive (false);
		Time.timeScale = 1f;
		Checkpause = false;
	}

	public void LoadMeun()
	{
		SwitchScene ss = new SwitchScene();
		ss.switchscene ("MainMeun");
		Time.timeScale = 1f;
	}

	public void QuitGame()
	{
		Debug.Log ("QuitGame");
		//Animation of Mr.Fish open a portol and anne go inside
		Application.Quit();
	}

	public void SettingUI()
	{
		if (Input.GetKeyDown (KeyCode.Escape) || CrossPlatformInputManager.GetButton("Pause")) {
			if (Checkpause) {
				Resume();
			}else{
				Pause();
			}
		}
		/*public Texture2D fadeOutTexture;
		public float fadeSpeed = 0.8f;

		private int drawDepth = -1000;
		private float alpha = 1.0f;
		private int fadeDir = -1;

		void OnGUI()
		{
			alpha += fadeDir * fadeSpeed * Time.deltaTime;
			alpha = Mathf.Clamp01 (alpha);
			GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
			GUI.depth = drawDepth;
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
		}

		public float BeginFade(int dir)
		{
			fadeDir = dir;
			return(fadeSpeed);
		}

		void OnLevelWasLoaded()
		{
			BeginFade (-1);
		}*/
	}
}

