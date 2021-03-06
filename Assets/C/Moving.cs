﻿using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour {

	public Transform body;
	public Transform Camera1;
	public float speed;
	public int singleStep = 1;
	Vector3 CameraDist;
	float PeopleAng;
	//float dis = 0.001f;
	//float speedTime = 2.5f;
//	bool moving =false;
	int nowDir = 0;//0:forward, 1:left, 2: back, 3:right
	// Use this for initialization
	void Start () {
		CameraDist=Camera1.position- body.position;

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 fwd = body.TransformDirection (Vector3.forward);
		if(Input.GetKey(KeyCode.Space)){
			Toforward();
//			moving = true;
		}

//		if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W)){
//			moving = false;
//		}

		
		if(Input.GetMouseButtonDown(0)){
			Toleft();
		}


		if (Input.GetKey(KeyCode.Space)) {
			Debug.DrawLine (body.position, body.position + fwd*5, Color.cyan);
			print ("Draw line");
				}
		//body.transform.Translate (new Vector3 (0, 1f, 0) * Mathf.Sin (Time.time*speedTime) * dis);
		Camera1.position = CameraDist+body.position;
//		if(Input.GetKey(KeyCode.Space)){
//
//		}
	}

	void Toforward(){

		for (int i=0; i<singleStep; i++) {
			Vector3 move = new Vector3(0,0,0);
			if(nowDir == 0)
			{
				move = new Vector3(0,0,speed); //print ("0");
			}
			if(nowDir == 1)
			{
				move = new Vector3(speed,0,0); //print ("1");
			}
			if(nowDir == 2)
			{
				move = new Vector3(0,0,-speed); //print ("2");
			}
			if(nowDir == 3)
			{
				move = new Vector3(-speed,0,0);// print ("3");
			}

			body.transform.Translate (move , Space.World);




			//print ("in Toforward for");
			//Debug.Log (body.transform.eulerAngles.y);
		}
	}


	void Toleft(){
		body.transform.Rotate (new Vector3 (0, 90f, 0), Space.World);
		nowDir ++;
		NowDirection ();
	}

	void NowDirection(){
		if (nowDir >= 0) {
			nowDir %= 4;
		} else {
			nowDir = Mathf.Abs(nowDir);
			nowDir %= 4;
			nowDir = 4-nowDir;
		}
	}
}
