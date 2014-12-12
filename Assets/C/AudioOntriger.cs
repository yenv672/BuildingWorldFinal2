using UnityEngine;
using System.Collections;

public class AudioOntriger : MonoBehaviour {

	string Who = "People";

	void OnTriggerEnter(Collider inter ){

		string name = inter.name;
		//print (inter.name);
		//print (name);

		if (!audio.isPlaying && name == Who) {
				audio.Play ();
				//print ("play");
		}//if
				
	}//Ontri
}
