using UnityEngine;
using System.Collections;

public class BuildRoad : MonoBehaviour {

	public Transform BuildItem;
	public Transform AreaTop;

	public float length;

	// Use this for initialization
	void Start () {
		StartCoroutine (build ());
	}
	
	IEnumerator build(){
		Vector3 NewZ = BuildItem.position;
		while (BuildItem.position.z < AreaTop.position.z) {
			//Debug.Log(BuildItem.position.z+"  "+ AreaTop.position.z);
			Instantiate(BuildItem,NewZ,Quaternion.identity);
			NewZ.z += length;
			BuildItem.transform.Translate(new Vector3(0,0,length));
				}
		yield break;
	}
}
