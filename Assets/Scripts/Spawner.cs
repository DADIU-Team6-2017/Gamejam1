﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] ObstacleCollection;
    public Transform spawnPoint;
	private Random rnd;
	public float obstacleSpeed;
    public float bpm = 120;
    public bool isSpawning;
	public int fourBarSurvive;

	private bool randomOrder = false;
	private float delay;
	private int  obstacleCount;


	// Use this for initialization
	void Start () {

		delay = 60 / bpm;
        spawnPoint = GameObject.Find("StartPoint").transform;
        isSpawning = true;
		obstacleCount = 0;
		SetObstacleSpeed ();
		if (randomOrder) {
			StartCoroutine (RandomInstantiator (delay));
		} else {
			StartCoroutine (OrderedInstantiator (delay));
		}
    
	}
	

	IEnumerator RandomInstantiator (float delay)
    {
        Instantiate(ObstacleCollection[Random.Range(0, ObstacleCollection.Length)], spawnPoint);
		obstacleCount += 1; 
        yield return new WaitForSeconds(delay);
		if (isSpawning) {
			StartCoroutine (RandomInstantiator (delay));
		}
    }

	IEnumerator OrderedInstantiator(float delay){
		if (ObstacleCollection.Length - 1 >= obstacleCount) {
			if (ObstacleCollection [obstacleCount] != null) {
				GameObject obstacle = Instantiate (ObstacleCollection [obstacleCount], spawnPoint);
				obstacleCount += 1;
				print (obstacleCount);
				if (obstacleCount % fourBarSurvive == 0) {
					obstacle.GetComponent<ObstacleMove> ().InvokeCheckPlayerPosition();
				}
				yield return new WaitForSeconds (delay);
				if (isSpawning) {
					StartCoroutine (OrderedInstantiator (delay));
				}

			} else {
				obstacleCount += 1; 
				yield return new WaitForSeconds (delay);
				StartCoroutine (OrderedInstantiator (delay));

			}
		} else {
			obstacleCount = 0; 
			StartCoroutine (OrderedInstantiator (delay));
		}

	}

	void SetObstacleSpeed(){
		foreach(GameObject obj in ObstacleCollection){
			if (obj != null) {
				obj.GetComponent<ObstacleMove> ().speed = obstacleSpeed;
			}
		}
	}
}
