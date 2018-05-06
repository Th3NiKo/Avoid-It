using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour {

	float whereToSpawn;
	Vector2 pos;
	GameObject roar;
	float roarCounter;
	bool roarActive;
	void Start () {
		whereToSpawn = Random.Range(0.45f, 0.80f);
		roar = transform.GetChild(0).gameObject;
		roarCounter = 2.0f;
		roarActive = false;
	}
	
	
	void Update () {

		if(!roarActive){
			pos = Camera.main.WorldToViewportPoint(transform.position);
			if(pos.x <= whereToSpawn){
				if(roar != null)
				roar.SetActive(true);
				roarActive = true;
			}
		} else {
			roarCounter -= Time.deltaTime;
			if(roarCounter <= 0){
				if(roar != null)
				roar.SetActive(false);
			}
		}
	}
}
