using UnityEngine;
using System.Collections;

public class bodyMovement : MonoBehaviour {

	float dis = 0.01f;
	float speedTime = 2.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0, 1f, 0) * Mathf.Sin (Time.time*speedTime) * dis);
	}
}
