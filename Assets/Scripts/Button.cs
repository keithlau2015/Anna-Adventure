using System;
using UnityEngine;
using UnityStandardAssets;

public class Button : MonoBehaviour
{
	public GameObject Button_press, Button_unpress;
	private static bool interact;
	void Start(){
		interact = false;
		ButtonUnpress ();
	}

	void OnTriggerEnter2D(Collider2D player){
		if (player.CompareTag ("Player")) {
			interact = true;
		}
	}

	void OnTriggerExit2D(){
		interact = false;
	}

	public bool getInteract(){
		return interact;
	}

	public void ButtonPressed(){
		Button_press.SetActive (true);
		Button_unpress.SetActive (false);
	}

	public void ButtonUnpress(){
		Button_press.SetActive (false);
		Button_unpress.SetActive (true);
	}
}
