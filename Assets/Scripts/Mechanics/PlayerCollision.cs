using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer("DuckLayer"))
		{
			Debug.Log("Touched duckLayer");
		}else if(collision.collider.gameObject.layer == LayerMask.NameToLayer("JumpLayer"))
		{
				Debug.Log("Touched JumpLayer");
		}else if(collision.collider.gameObject.layer == LayerMask.NameToLayer("PhaseLayer"))
		{
				Debug.Log("Touched PhaseLayer");
		}
	}
		
}
