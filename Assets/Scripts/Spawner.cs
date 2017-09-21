using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] ObstacleCollection;
    public Transform spawnPoint;
    public Transform endPoint;
    public Random rnd;
	public float obstacleSpeed;
    public float delay;
    public bool IsSpawning;

	// Use this for initialization
	void Start () {
        spawnPoint = GameObject.Find("StartPoint").transform;
        endPoint = GameObject.Find("EndPoint").transform;
        IsSpawning = true;
		SetObstacleSpeed ();
        StartCoroutine(Instantiator(delay));
    }
	

    IEnumerator Instantiator ( float delay)
    {
        Instantiate(ObstacleCollection[Random.Range(0, ObstacleCollection.Length)], spawnPoint);

        yield return new WaitForSeconds(delay);
        if(IsSpawning)
            StartCoroutine(Instantiator(delay));

    }

	void SetObstacleSpeed(){
		foreach(GameObject obj in ObstacleCollection){
			obj.GetComponent<ObstacleMove> ().speed = obstacleSpeed;
		}
	}
}
