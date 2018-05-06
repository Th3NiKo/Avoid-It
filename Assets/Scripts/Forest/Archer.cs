using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour {

	public GameObject arrow;
	bool oneshot;
	float firstShot;
	float secondShot;

	bool first;
	bool second;
	Vector3 pos;
	void Start () {
		oneshot = (Random.value > 0.5f);
		firstShot = Random.Range(0.75f, 0.9f);
		secondShot = Random.Range(0.4f, 0.55f);
		first = false;
		second = false;
	}
	
	
	void Update () {
		pos = Camera.main.WorldToViewportPoint(transform.position);
		if(!first){
			if(pos.x <= firstShot){
				Instantiate(arrow, transform.position, Quaternion.identity);
				first = true;
			}
		}

		if(!second && !oneshot){
			if(pos.x <= secondShot){
				Instantiate(arrow, transform.position, Quaternion.identity);
				second = true;
			}
		}
		
	}
}
