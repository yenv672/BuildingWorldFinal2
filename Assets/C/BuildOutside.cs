using UnityEngine;
using System.Collections;

public class BuildOutside : MonoBehaviour {

	public Transform BuildItem;
	public int NumberOfBuilding;
	public Transform TopBound;
	public Transform RightBound;

	 float surrounding = 13f;
	 int HowmanyZ = 4;
	 int HowmanyX = 3;
	bool[] record ;
	Vector3 newPlaceToBuild;

	// Use this for initialization
	void Start () {
		//HowmanyZ = (int)Mathf.Floor((TopBound.position.z - BuildItem.position.z) / surrounding);
		//HowmanyX = (int)Mathf.Floor((RightBound.position.x - BuildItem.position.x) / surrounding);

		record = new bool[HowmanyX*HowmanyZ+1];
		for (int i=0; i<record.Length; i++) {
			record[i]=false;
			//print ("record "+i+" now is " + record[i]);
				}
		StartCoroutine ( BuildingOut ());
	}
	
	IEnumerator BuildingOut(){

		while (NumberOfBuilding>0) {
			newPlaceToBuild = BuildItem.position;
			int A = 0;
			A = Random.Range(1,HowmanyX*HowmanyZ+1);
			print ("A now is "+A+" record[A] is "+record[A]);
			if(record[A] ==false){
			//print ("inside");
			BuildPosition(A);
			NumberOfBuilding--;
			print ("NumverOf now is "+NumberOfBuilding);
			}
		}
		yield break;
	}

	void BuildPosition(int pos){
		//print ("inside buildPos");
		int muitX;
		int muitZ;
		muitX = pos % HowmanyX;
		muitZ = (int)Mathf.Floor(pos/HowmanyZ);
		if (muitZ > HowmanyZ) {
			muitZ = HowmanyZ;
				}
		print ("muitX = "+muitX+" muitZ = "+muitZ);
		newPlaceToBuild.x += muitX * surrounding;
		newPlaceToBuild.z += muitZ * surrounding;
		record [pos] = true;
		print ("record[pos] now is " + record [pos]);
		Instantiate(BuildItem, newPlaceToBuild, Quaternion.identity);
	}
}
