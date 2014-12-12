using UnityEngine;
using System.Collections;

public class TurnoffThelight : MonoBehaviour {

	public Light lightMain;
	int now =1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (now == 1) {
			lightMain.intensity = 0.5f;
		}
		if(now == 0)
		{
			lightMain.intensity = 0.2f;
		}
	}

	void LightMode(int state)
	{
		now = state;
		gameObject.SendMessage ("getnow", state);
	}
}
