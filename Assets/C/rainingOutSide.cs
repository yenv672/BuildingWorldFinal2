using UnityEngine;
using System.Collections;

public class rainingOutSide : MonoBehaviour {

	public Transform me;
	public float distant;
	public TextMesh Dialog;
	public Color noColor;
	public string talking;
	bool textShow = false;
	int counttext;
	GameObject glassClient;
	public int countDown=150;

	// Use this for initialization
	void Start () {
		counttext = talking.Length;
		glassClient = GameObject.FindWithTag ("glass");
	}
	
	// Update is called once per frame
	void Update () {

		//print ("tag position"+glassClient.transform.position);//it is not work~"~
	
		if (Vector3.Distance (me.position, glassClient.transform.position) < distant && !textShow) {
			//print ("trigger");
			Dialog.color = noColor;
			//			Dialog.text = talking;
			typing(talking);
			
		}
		
		if (textShow) {
			countDown--;
			if(countDown<0 && noColor.a>0){
				noColor.a -=0.05f;
				Dialog.color = noColor;
			}
		}

	}

	void typing(string talk){
		
		
		//print ("in typing");
		
		if (counttext>0) {
			
			string temp ="";
			//print ("in typing while");
			for (int i=0; i<talk.Length-counttext+1; i++) {
				temp += talk[i];
				//print ("temp"+temp);
			}
			//print("in typing while dialog");
			Dialog.text = temp;
			counttext--;
			
			
		}
		
		if (counttext == 0) {
			textShow = true;
		}
	}
}
