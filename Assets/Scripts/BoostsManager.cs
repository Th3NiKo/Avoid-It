using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostsManager : MonoBehaviour {

	public GameObject[] points;
	public float minCooldown;
	public float maxCooldown;

	private float actualCooldown;
	private float spawnTimer;
	bool spawnPoints;

	void Start () {
		spawnPoints = true;
		spawnTimer = 0.0f;
		actualCooldown = Random.Range(minCooldown, maxCooldown);
	}
	
	
	void Update () {
		if(spawnPoints){
			spawnTimer += Time.deltaTime;
			if(spawnTimer >= actualCooldown){
				//Spawn boost
				float whichOne = Random.Range(0.0f, 1.0f);
				float spawnX = Random.Range(0.08f, 0.92f);
				float spawnY = Random.Range(0.08f, 0.92f);
				Vector3 whereToSpawn = Camera.main.ViewportToWorldPoint(new Vector3(spawnX, spawnY, transform.position.z));
				whereToSpawn.z = 1.0f;
				for(int i = 0; i < points.Length; i++){
					int value = points[i].GetComponent<Points>().value;
					if(value == 100){
						if(whichOne >= 0.0f && whichOne <= 0.05f){
							Instantiate(points[i], whereToSpawn, Quaternion.identity);
						}
					} else if(value == 50){
						if(whichOne > 0.05f && whichOne <= 0.15f){
							Instantiate(points[i], whereToSpawn, Quaternion.identity);
						}
					} else if(value == 10){
						if(whichOne > 0.15f && whichOne <= 0.3f){
							Instantiate(points[i], whereToSpawn, Quaternion.identity);
						}
					} else if(value == 5){
						if(whichOne > 0.3f && whichOne <= 0.5f){
							Instantiate(points[i], whereToSpawn, Quaternion.identity);
						}
					} else if(value == 1){
						if(whichOne > 0.5f && whichOne <= 0.8f){
							Instantiate(points[i], whereToSpawn, Quaternion.identity);
						}
					}
				}
				spawnTimer = 0.0f;
				actualCooldown = Random.Range(minCooldown, maxCooldown);
			}
		
		}
	}

	public void TurnPoints(bool on){
		spawnPoints = on;
	}
}
