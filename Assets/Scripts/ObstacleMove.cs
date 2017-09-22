using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour {

	public float speed; 
	public float threshold;
	public Transform player; 

	// Use this for initialization
	void Start () {
		InvokeRepeating ("CheckPosition",0f,0.2f);
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

	public void InvokeCheckPlayerPosition(){
		print ("checkpos");

		player = GameObject.Find ("Player").transform;
		InvokeRepeating ("CheckPlayerPosition", 0f, 0.05f);
	}

	void CheckPlayerPosition (){
		if (player.transform.position.x > this.gameObject.transform.position.x) {
			PlaySoundAtPlayer ();
		}
	}

	void PlaySoundAtPlayer(){
		CancelInvoke ("CheckPlayerPosition");
		GameObject soundObj = GameObject.Find ("Sounds");
		SoundScript soundScr = soundObj.GetComponent<SoundScript> ();
		AudioSource sound = soundObj.GetComponent<AudioSource>();
		sound.clip = soundScr.FourBarSurviveSounds[Random.Range(0,soundScr.FourBarSurviveSounds.Length)];
		sound.Play();

		//sound.PlayOneShot(soundScr.FourBarSurviveSounds[Random.Range(0,soundScr.FourBarSurviveSounds.Length)]);
		//GameObject soundObj = GameObject.Find ("Sounds");
		//AudioSource sound = soundObj.GetComponent<AudioSource>();
		//sound.clip = soundObj.GetComponent<SoundScript> ().FourBarSurviveSounds [Random.Range (0, soundObj.GetComponent<SoundScript> ().FourBarSurviveSounds.length)];
			
	}
		
}
