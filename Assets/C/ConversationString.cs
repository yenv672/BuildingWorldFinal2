using UnityEngine;
using System.Collections;

public class ConversationString : MonoBehaviour {
	
	public Transform Client;
	public Transform Me;
	public string[] talking;
	public TextMesh Dialog;
	public int AlphacountDown = 255;

	bool interact = false;
	int AlphaDisapear;
	bool[] textShow = new bool[5];
	int[] counttext = new int[5];
	int now = 0;
	float a = 1;
	Color Original = new Color (1, 1, 1, 1);
	float AlphaDecrese = 0.05f;
	int resetTime = -50;
	
	void Start(){
		for (int i=0; i<talking.Length; i++) {
			counttext[i] = talking[i].Length;
			textShow[i] = false;
						//print ("counttext" + counttext);
				}
		AlphaDisapear = AlphacountDown;
	}

	void getnow(int nowGet)
	{
			AlphaDisapear = AlphacountDown;
			now = nowGet;
			Dialog.text = "";
			textShow [now] = false;
			counttext[now] = talking[now].Length;
			Dialog.color = Original;// make the world color to full color
			a = Original.a;
			interact = true;
		//Update ();
		}

	// Update is called once per frame
	void Update () {
		if (interact) {

						//if is inside enough and the text haven't showed THEN Show
						if (!textShow [now]) {
								//print ("trigger");
								
								//Dialog.text = talking[now];
								typing (talking);
								//textShow[now] = true;
						}//if !textshow

				}//if interact
		
	}


	void typing(string[] talk){

		//print ("in typing");
		
		if (counttext[now]>0) {
			
			string temp ="";
			//print ("in typing while");
			for (int i=0; i<talk[now].Length-counttext[now]+1; i++) {
				temp += talk[now][i];
				//print ("temp"+temp);
			}
			//print("in typing while dialog");
			Dialog.text = temp;
			Dialog.color = Original;// make the world color to full color
			a = Dialog.color.a;

			counttext[now]--;
			//print (counttext[now]);
			
		}
		
		if (counttext[now] == 0) {
			textShow[now] = true;
			disappear();
		}
	}

	void disappear(){
		
		AlphaDisapear--; //print ("textShow[now]"+textShow[now]);print ("nocolor.a"+noColor.a);
		if (AlphaDisapear < 0 && Dialog.color.a > 0) {
			
			a -= AlphaDecrese;
			if(a<0){a=0;}
			Dialog.color = new Color (1, 1, 1, a);
			;
			//print ("Dia color"+ Dialog.color);
			if (Dialog.color.a == 0 && AlphaDisapear < resetTime) {
				textShow [now] = false;
				interact = false;
				AlphaDisapear = AlphacountDown;
			}
		}
	}

}
