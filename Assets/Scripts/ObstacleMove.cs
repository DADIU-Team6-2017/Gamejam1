using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour {

	public float speed; 
	public float threshold;
	//spawnScript spawnScript;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("CheckPosition",0f,0.2f);
		//speed = GetComponent<spawnScript> ().distance;
	}
	
	// Update is called once per frame
	void Update () {



	}

	void FixedUpdate(){
		transform.Translate(new Vector3(-speed,0,0) * Time.deltaTime);
	}

	void CheckPosition(){
		Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);

		if (screenPoint.x < 0+threshold) {
            Destroy(this.gameObject);
		}
	}

}
