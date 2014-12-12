using UnityEngine;
using System.Collections;

public class typing : MonoBehaviour {

	public string[] talking;
	public TextMesh Dialog;
	public float AlphaDecrese = 0.05f;

	bool[] textShow = new bool[5];
	int[] counttext = new int[5];
	int now = 0;
	float a = 1;
	Color Original = new Color (1, 1, 1, 1);


	// Use this for initialization
	void Start () {
		for (int i=0; i<talking.Length; i++) {
			counttext[i] = talking[i].Length;
			textShow[i] = false;
			//print ("counttext" + counttext);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (textShow [now] == false && now<talking.Length) {
			type (talking);
				}
		if (textShow [now] == true) {
			now++;
				}
		if (now >= talking.Length) {
			//SendMessage("startIt",true);
			Application.LoadLevel (1);
				}
	}
	void type(string[] talk){
		
		//print ("in typing");
		
		if (counttext[now]>0) {
			
			string temp ="";
			//print ("in typing while");
			for (int i=0; i<talk[now].Length-counttext[now]+1; i++) {
				temp += talk[now][i];
				//print ("temp"+temp);
			}
			//print("in typing while dialog");
			Dialog.color = Original;// make the world color to full color
			a = Original.a;
			Dialog.text = temp;
			counttext[now]--;
			//print (counttext[now]);
			
		}
		
		if (counttext[now] == 0) {
			disappear();
		}
	}
	
	void disappear(){

		if (Dialog.color.a > 0) {
				
			print ("a now is "+a);
				a -= AlphaDecrese;
				if(a<0){
					a=0;
				}
				Dialog.color = new Color (1, 1, 1, a);

				} else {
					textShow[now] = true;
				}
	}
}
