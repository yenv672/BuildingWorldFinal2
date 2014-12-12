using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public int  CountDown;
	public TextMesh Count;
	float timer = 0f;
	int timerInt = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int NowLeft;
		timer += Time.deltaTime;
		timerInt = (int)timer;
		//Debug.Log (timerInt);
		NowLeft = CountDown - timerInt;
		//Debug.Log (NowLeft);
		Count.text = "Left "+ NowLeft+" sec";
		if (NowLeft == 0) {
			Application.LoadLevel(0);
		}

	}
}
