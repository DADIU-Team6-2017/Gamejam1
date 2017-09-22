using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDelay : MonoBehaviour {

	AudioSource audioSource;
	public float delay; 

	// Use this for initialization
	void Start () {

		audioSource = this.GetComponent<AudioSource>();
		audioSource.PlayDelayed (delay);

	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
