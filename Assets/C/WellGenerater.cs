using UnityEngine;
using System.Collections;

public class WellGenerater : MonoBehaviour {

	public Transform Wall;

	public int BuildLeft;
	public int Left;
	public int BuildRight;
	public int Right;
	public int Top;

	public Transform BuildLeftStart;
	public Transform BuildRightStart;
	public Transform RightStart;
	public Transform LeftStart;
	public Transform TopStart;
	
	public float lenght;

	int buildState = 0;

	// Use this for initialization
	void Start () {
		StartCoroutine (BuildWall ());
	}
	IEnumerator BuildWall(){

		Vector3 BLS = BuildLeftStart.position;
		Vector3 BRS = BuildRightStart.position;
		Vector3 LS = LeftStart.position;
		Vector3 RS = RightStart.position;
		Vector3 TS = TopStart.position;
		//Debug.Log ("IEHere");
		while (buildState<5) {
			//Debug.Log ("While Here");
			if(BuildLeft>0){
				Instantiate(Wall,BLS,Quaternion.Euler(0,90f,0));
				BLS.x-=lenght;
				BuildLeft--;
				if(BuildLeft == 0)
				{
					buildState++;
				}
			}

			if(BuildRight>0){
				Instantiate(Wall,BRS,Quaternion.Euler(0,90f,0));
				BRS.x+=lenght;
				BuildRight--;
				if(BuildRight == 0)
				{
					buildState++;
				}
			}

			if(Left>0){
				Instantiate(Wall,LS,Quaternion.identity);
				LS.z+=lenght;
				Left--;
				if(Left == 0)
				{
					buildState++;
				}
			}

			if(Right>0){
				Instantiate(Wall,RS,Quaternion.identity);
				RS.z+=lenght;
				Right--;
				if(Right == 0)
				{
					buildState++;
				}
			}

			if(Top>0){
				Instantiate(TopStart,TS,Quaternion.Euler(0,90f,0));
				TS.x-=lenght;
				Top--;
				if(Top == 0)
				{
					buildState++;
				}
			}
		}

		yield break;

	}
}
