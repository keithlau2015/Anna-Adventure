using System;
using UnityEngine;

public class Door : MonoBehaviour{
	public GameObject Door_open, Door_close;
	private int checkTrigger;
	public bool interact;

	void Start()
	{
		interact = false;
		checkTrigger = 0;
		DoorDefault ();
	}

	void OnTriggerEnter2D(Collider2D player)
	{
		++checkTrigger;
		if (player.CompareTag ("Player") && isNonTrigger()==false) {
			Door_close.SetActive (false);
			Door_open.SetActive (true);
			interact = true;
		}
	}

	void OnTriggerExit2D()
	{
		--checkTrigger;
		DoorDefault ();
		interact = false;
	}

	bool isNonTrigger()
	{
		if (checkTrigger == 0) {
			return true;
		} else {
			return false;
		}
	}

	public bool getInteract()
	{
		return interact;
	}

	void DoorDefault()
	{
		Door_close.SetActive (true);
		Door_open.SetActive (false);
	}
}