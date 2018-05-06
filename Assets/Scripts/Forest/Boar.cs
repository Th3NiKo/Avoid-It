using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar : MonoBehaviour {

	float timerOfStop;
	Vector2 pos;
	Rigidbody2D rgb;
	bool getPoint;
	bool setPosition;
	Vector3 whereToGo;
	float speed;
	Vector3 originPosition;
	bool ready;
	void Start () {
		timerOfStop = 1.2f;
		rgb = GetComponent<Rigidbody2D>();
		getPoint = false;
		speed = Random.Range(6.6f, 8.0f);
		whereToGo = new Vector3(0f,0f,0f);
		setPosition = false;
		originPosition = new Vector3(0f,0f,0f);
		ready = false;
	}
	
	
	void Update () {
		pos = Camera.main.WorldToViewportPoint(transform.position);
		if(pos.x <= 0.93f){
			ready = true;
		}

		if(ready){
			if(timerOfStop >= 0.0f){
				if(!setPosition){
					originPosition = transform.position;
					setPosition = true;
				}
				transform.position = originPosition + Random.insideUnitSphere * 0.1f;
				rgb.velocity = new Vector3(0f,0f,0f);
				
				timerOfStop -= Time.deltaTime;
			} else {
				if(!getPoint){
					whereToGo = GameObject.Find("Player").transform.position;

					getPoint = true;
				}
				rgb.velocity = new Vector2(whereToGo.x - originPosition.x, whereToGo.y - originPosition.y);
				//transform.position = test;
				//transform.position = Vector3.MoveTowards(transform.position, whereToGo, speed * Time.deltaTime);
			}
		}
	}
}
