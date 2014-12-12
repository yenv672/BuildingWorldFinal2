using UnityEngine;
using System.Collections;

public class Conversation : MonoBehaviour {

	public Transform Client;
	public Transform Me;
	public string talking;
	public float interactDis;
	public TextMesh Dialog;
	public Color noColor;
	bool textShow = false;
	int counttext;
	public int countDown=150;

	void Start(){
		counttext = talking.Length;
		//print ("counttext" + counttext);
	}
	// Update is called once per frame
	void Update () {
		//print ("Me now"+Me.position);
		//print ("Client now"+Client.position);
		//print ("Out dis"+Vector3.Distance (Me.position, Client.position));
		if (Vector3.Distance (Me.position, Client.position) < interactDis && !textShow) {
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


