using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

	// Use this for initialization
	public LayerMask wall_layer, player_layer; //障礙物,

	private Rigidbody2D my_rigi; //monster Rigidbody
	private GameObject player_object; //玩家
	private Vector3 player_pos, monster_pos; //player,monster 座標
	private const float JUMP = 5f; //monster跳躍力
	private const float SPEED = 0.05f; //monster速度
	private const float RADIUS = 3f; //monster捕捉半徑
	void move () {
		if (touchCircleRange ()) {
			//Time.timeScale = 0f; //待修!!!
		}

		/**********移動**********/
		float distance = 0.5f;
		Vector3 end = monster_pos;
		if (monster_pos.x + RADIUS < player_pos.x) {
			gameObject.transform.Translate (SPEED, 0, 0); //改變BOSS位置
			end = new Vector3 (monster_pos.x + distance, monster_pos.y); //改變BOSS方向
		} else if (monster_pos.x - RADIUS > player_pos.x) {
			gameObject.transform.Translate (-SPEED, 0, 0);
			end = new Vector3 (monster_pos.x - distance, monster_pos.y);
		}
		/**********移動**********/

		/**********跳躍**********/
		if (checkJump ()) {
			Debug.DrawLine (monster_pos, end, Color.blue);
			if (Physics2D.Linecast (monster_pos, end, wall_layer) || monster_pos.y + RADIUS < player_pos.y && Mathf.Abs (monster_pos.x - player_pos.x) < RADIUS) {
				my_rigi.velocity = Vector3.up * JUMP;
			}
		}
		/**********跳躍**********/
	}
	bool checkJump () {
		float flor_dis = 1.6f;
		Vector3 end = new Vector3 (monster_pos.x, monster_pos.y - flor_dis);
		Debug.DrawLine (monster_pos, end, Color.blue);
		return Physics2D.Linecast (monster_pos, end, wall_layer);
	}

	bool touchCircleRange () {
		const int ADDANGLE = 10;
		Vector3 point1 = new Vector3 (monster_pos.x + RADIUS * Mathf.Cos (0 * Mathf.Deg2Rad), monster_pos.y + RADIUS * Mathf.Sin (0 * Mathf.Deg2Rad));
		for (int angle = ADDANGLE; angle <= 360; angle += ADDANGLE) {
			Vector3 point2 = new Vector3 (monster_pos.x + RADIUS * Mathf.Cos (angle * Mathf.Deg2Rad), monster_pos.y + RADIUS * Mathf.Sin (angle * Mathf.Deg2Rad));
			Debug.DrawLine (point1, point2, Color.red);
			if (Physics2D.Linecast (point1, point2, player_layer)) return true;
			point1 = point2;
		}
		if (Mathf.Pow (monster_pos.x - player_pos.x, 2) + Mathf.Pow (monster_pos.y - player_pos.y, 2) <= RADIUS * RADIUS) return true;
		else return false;
	}
	void Start () {
		player_object = GameObject.Find ("player_character"); //可修
		my_rigi = GetComponent<Rigidbody2D> ();
	}
	// Update is called once per frame
	void Update () {
		player_pos = player_object.GetComponent<Transform> ().position;
		monster_pos = gameObject.transform.position;
		move ();
	}
	void FixedUpdate () { }
}