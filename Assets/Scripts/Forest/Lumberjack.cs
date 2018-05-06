using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumberjack : MonoBehaviour {

	float whereToSpawn;
	bool isSpawned;
	Vector2 pos;
	public GameObject axe;
	GameObject axeCreated;
	void Start () {
		whereToSpawn = Random.Range(0.7f, 0.85f);
		isSpawned = false;
	}
	
	
	void Update () {
		if(!isSpawned){
			pos = Camera.main.WorldToViewportPoint(transform.position);
			if(pos.x <= whereToSpawn){
				axeCreated = Instantiate(axe ,transform.position, Quaternion.identity);
				Invoke("Throw", 1.5f);
				isSpawned = true;
			}
		} else {
			if(axeCreated != null){
				axeCreated.transform.eulerAngles = new Vector3(0.0f, 0.0f, axeCreated.transform.eulerAngles.z + 4f);
			}
		}
		
	}


	void Throw(){
		float angle = Random.Range(0f,1f);
		float speed = Random.Range(3.5f, 6f);
		if(Camera.main.WorldToViewportPoint(axeCreated.transform.position).y >= 0.5f){ 
			//Upper half
			axeCreated.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, -angle) * speed;
		} else {
			//Bottom half
			axeCreated.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, angle) * speed;
		}
	}
}
