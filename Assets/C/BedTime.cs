using UnityEngine;
using System.Collections;

public class BedTime : MonoBehaviour {

	public Light Control;
	public TextMesh dia;
	public int CountDOwn = 3000;
	int bedTimeOrNot = 0;

	// Use this for initialization
	void Start () {

	}
	void GetBed(int i){
		bedTimeOrNot = i;
		}
	// Update is called once per frame
	void Update () {
		if (bedTimeOrNot == 1) {
			dia.text ="You go to bed...";
			CountDOwn--;
			Control.enabled = false;
			//print(CountDOwn);
			if(CountDOwn<=0)
			{
				Application.LoadLevel(0);
			}
				}
	}
}
