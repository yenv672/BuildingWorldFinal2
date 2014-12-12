using UnityEngine;
using System.Collections;

public class Ai2_boy : MonoBehaviour {

	public Transform Me;
	public Transform gate;
	public Transform gate2;
	public Transform Interact;
	 float length = 1.5f;
	bool ifOver = false;
	public float speed = 0.05f;
	public float speedAfter = 0.1f;
	 int singleStep = 1;
	bool ifInterAct = false;
	float surround = 1.5f;
	int returnTimer = 150;
	bool ZmoveOver = false;
	int casesaving;
	//bool XmoveOver = false;
	// Use this for initialization
	void Start () {
	
	}
	void Stop(int now){
		if (now == 0) {
			ifInterAct = false;
		} else {
			ifInterAct =true;
		}
	}
	// Update is called once per frame
	void Update () {
		if (ifInterAct && !ifOver) {
			returnTimer--;
			if(returnTimer == 0){
				ifInterAct = false;
				returnTimer = 150;
			}
		}
		if (!ifInterAct && !ifOver) {
			
			Vector3 fwd = transform.TransformDirection (Vector3.forward);
			//						Vector3 right = transform.TransformDirection (Vector3.right);
			//Debug.DrawLine (transform.position, transform.position + right * length, Color.green);
			//Debug.DrawLine (transform.position, transform.position + fwd * length, Color.cyan);
			
			if (!Physics.Raycast (transform.position, fwd, length)) {
				Toforward ();
			} else {
				//Toright();print ("in right");
				int decide = Random.Range (0, 2);
				switch (decide) {
				case 0:
					Toleft ();//print ("in left");
					break;
				case 1:
					Toright ();//print ("in right");
					break;
				}
				
			}
		}
		if (Me.position.z > gate.position.z && Me.position.z < gate2.position.z) {
			Interact.SendMessage("ChangeState",1);
			ifOver = true;
			startMoving();
		}
		if(Me.position.z > gate2.position.z){
			ifOver = false;
		}
		if ( ifOver == true && Me.position.z < gate.position.z) {
			ifOver = false;
			//Interact.SendMessage("ChangeState",0);
				}
	}

	void startMoving(){

		if (Vector3.Distance (Me.position, Interact.transform.position) > surround) {

				
						if (Me.position.z > Interact.transform.position.z && !ZmoveOver) {
								Interact.transform.Translate (new Vector3 (0, 0, speedAfter), Space.World);
				casesaving = 0;
								if (Me.position.z < Interact.transform.position.z) {
										ZmoveOver = true;
								}
						} else if (Me.position.z < Interact.transform.position.z && !ZmoveOver) {
								Interact.transform.Translate (new Vector3 (0, 0, -speedAfter), Space.World);
				casesaving =1;
								if (Me.position.z > Interact.transform.position.z) {
										ZmoveOver = true;
								}
						} 
						if (Me.position.x > Interact.transform.position.x && ZmoveOver) {
								Interact.transform.Translate (new Vector3 (speedAfter, 0, 0), Space.World);
				casesaving=2;
								ZmoveOver = false;

						} else if (Me.position.x < Interact.transform.position.x && ZmoveOver) {
								Interact.transform.Translate (new Vector3 (-speedAfter, 0, 0), Space.World);
				casesaving =3;
								
								ZmoveOver = false;

						}
				} else {
			switch(casesaving)
			{
			case 0:
				transform.eulerAngles = new Vector3 (0, 0, 0);
				break;
			case 1:
				transform.eulerAngles = new Vector3 (0, 180f, 0);
				break;
			case 2:
				transform.eulerAngles = new Vector3 (0, 90f, 0);
				break;
			case 3:
				transform.eulerAngles = new Vector3 (0, -90f, 0);
				break;
			}
				}
	}

	void moveX(){
		}

	void Toforward(){
		//print ("in Toforward");
		for (int i=0; i<singleStep; i++) {
			Vector3 move = new Vector3(0,0,speed);
			transform.Translate (move , Space.Self);
			//print ("in Toforward for");
		}
	}
	void Toleft(){
		transform.Rotate (new Vector3 (0, 90f, 0), Space.World);
	}
	void Toright(){
		transform.Rotate (new Vector3 (0, -90f, 0), Space.World);
	}
}
