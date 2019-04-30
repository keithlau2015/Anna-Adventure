using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	private PlayerController player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("PlayerController").GetComponent<PlayerController> ();
	}

	void onTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) {
			//player hp lose 1
		}
	}
}
