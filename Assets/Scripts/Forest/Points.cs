using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {

	public int value;
	public float timeToLive;
	SpriteRenderer spriteR;
	GameObject pointsObject;
	ObstaclesCleaner pointsCounter;

	float speedUp;
	Quaternion rotation;
	Quaternion min =  Quaternion.Euler(new Vector3(0f, 0f, -20f));
	Quaternion max = Quaternion.Euler( new Vector3(0f, 0f, 20f));
	bool hasBumped;
	bool goUp;
	float liveTimer;
	void Start () {
		pointsObject = GameObject.Find("ObstaclesCleaner");
		transform.localScale = new Vector3(0.1f, 0.1f, 1f);
		pointsCounter = pointsObject.GetComponent<ObstaclesCleaner>();
		spriteR = GetComponent<SpriteRenderer>();
		hasBumped = false;
		goUp = true;
		rotation = transform.rotation;
		liveTimer = 0f;
		speedUp = 1.0f;
	}
	
	
	void Update () {
		liveTimer += Time.deltaTime;
		speedUp += 1;
		if(!hasBumped){
			if(transform.localScale.x <= 1.0f){
				transform.localScale = new Vector3(transform.localScale.x + 0.04f, transform.localScale.y + 0.04f, 1.0f);
			} else {
				hasBumped = true;
			}
		} else {
			if(goUp){
				//transform.Rotate(new Vector3(0.0f, 0.0f, 1f));
				rotation.z += Quaternion.Euler (new Vector3 (0f, 0f, (100f + speedUp) * Time.deltaTime)).z;
				if(rotation.z >= max.z) goUp = false;
			} else {
				//transform.Rotate(new Vector3(0.0f, 0.0f,-1f));
				rotation.z -= Quaternion.Euler (new Vector3 (0f, 0f, (100f + speedUp) * Time.deltaTime)).z;
				if(rotation.z <= min.z) goUp = true;
			}
			transform.rotation = rotation;
		}
		//spriteR.color = new Color(spriteR.color.r, spriteR.color.g, spriteR.color.b,spriteR.color.a - 0.004f);
		if(liveTimer >= timeToLive){
			Destroy(this.gameObject);
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player"){
			pointsCounter.AddPoints(value);
			if(GetComponent<TextShow>() != null)
			GetComponent<TextShow>().CreateText(this.transform.position, this.spriteR.color, 30,"+" + value.ToString());
			Destroy(this.gameObject);
		}
	}
}
