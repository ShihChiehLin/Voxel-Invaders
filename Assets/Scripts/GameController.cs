using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public MapLimits Limits;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public float spawnTimer;
	float maxSpawnTimer;

	// Use this for initialization
	void Start () {
		SpawnEnemy ();
		maxSpawnTimer = spawnTimer;
	}
	
	// Update is called once per frame
	void Update () {
		spawnTimer -= Time.deltaTime;
		if (spawnTimer <= 0) {
			SpawnEnemy ();
			spawnTimer = maxSpawnTimer;
		}
	}

	void SpawnEnemy(){
		int randomNumber = Random.Range (0, 3);
		switch (randomNumber) {
		case 0:
			{
				Instantiate (enemy1, 
				new Vector3 (Random.Range (Limits.minimumX, Limits.maximumX), Random.Range (Limits.minimumY, Limits.maximumY),0), enemy1.transform.rotation);
			}
			break;
		case 1:
			{
				Instantiate (enemy2, 
					new Vector3 (Random.Range (Limits.minimumX, Limits.maximumX), Random.Range (Limits.minimumY, Limits.maximumY),0), enemy2.transform.rotation);
			}
			break;
		case 2:
			{
				Instantiate (enemy3, 
					new Vector3 (Random.Range (Limits.minimumX, Limits.maximumX), Random.Range (Limits.minimumY, Limits.maximumY),0), enemy3.transform.rotation);
			}
			break;
		default:
			{
				Instantiate (enemy1, 
					new Vector3 (Random.Range (Limits.minimumX, Limits.maximumX), Random.Range (Limits.minimumY, Limits.maximumY), 0), enemy1.transform.rotation);			
			}
			break;
		}
	}
}
