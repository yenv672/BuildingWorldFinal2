using UnityEngine;
using System.Collections;

public class StarttheGame : MonoBehaviour {

	bool startOrNot = false;

	// Use this for initialization
	void Start () {
	
	}
	void startIt(bool now){
		startOrNot = now;
		}
	// Update is called once per frame
	void Update () {
		if (startOrNot) {
						Application.LoadLevel (1);
				}
	}
}
