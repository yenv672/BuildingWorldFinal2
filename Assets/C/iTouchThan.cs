using UnityEngine;
using System.Collections;

public class iTouchThan : MonoBehaviour {

	public Transform Client;
	public Transform Me;
	public float interactDis = 1.5f;
	public string funtionName;
	public int[] message;
	public GameObject targetItem;
	public bool auto =false;
	public int TimeInsideTheInteractionZone = 30;
	public int timer = 250;
	//public bool IsSameObject = true;

	int nowMess;
	bool havesend = false;
	int TimerReset;
	int InSide;
	bool InsideEnough = false;

	// Use this for initialization
	void Start () {
		TimerReset = timer;
		nowMess = 0;
	}

	void ChangeState(int i){
		nowMess = i;
	}


	// Update is called once per frame
	void Update () {
	
		if (!InsideEnough) {
			InsideEnough = TimeInsideTheZoneSame (Client);
		}



		if(!havesend && InsideEnough)
		{
			//print ("I am inside");

				targetItem.SendMessage(funtionName,message[nowMess]);
			
			if(auto)
			{
				if(nowMess<message.Length-1)
				{
					nowMess++;
				}else{
					nowMess=0;
				}
			}
			havesend = true;
		}

		if (havesend) {
			TimerReset--;
			if(TimerReset == 0){
				havesend = false;
				TimerReset = timer;
				InsideEnough = false;
				//print ("Timer reset");
			}
		}

	}

	bool TimeInsideTheZoneSame(Transform Compare){

		if (Vector3.Distance (Me.position, Compare.position) < interactDis) {
			//print ("Inside Enough : "+ InSide);
			InSide --;//while is inside countdown;
			if (InSide == 0) {
				InSide = TimeInsideTheInteractionZone;
				return true;
			}
			return false;
		} else {
			InSide = TimeInsideTheInteractionZone;
			return false;

		}
		
	}




}
