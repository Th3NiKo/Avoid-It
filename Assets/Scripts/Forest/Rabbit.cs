using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour {

	float jumpTimer;
	Rigidbody2D rgb;
	Vector2 jumpVector;

	float speed;
	void Start () {
		speed = Random.Range(2.2f, 5.0f);
		transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
		jumpTimer = 0.0f;
		rgb = GetComponent<Rigidbody2D>();
		jumpVector = new Vector2(-1.0f, 1.0f);
	}

	void Update () {
		jumpTimer += Time.deltaTime;

		if(jumpTimer >= 1.0f){
			jumpVector.y = jumpVector.y * -1;
			jumpTimer = 0.0f;
		}
		rgb.velocity = jumpVector * speed;
		KeepOnScreen();

	}

	void KeepOnScreen(){
		var pos = Camera.main.WorldToViewportPoint(transform.position);
 		pos.y = Mathf.Clamp(pos.y, 0.02f, 0.98f);
 		transform.position = Camera.main.ViewportToWorldPoint(pos);
	}
}
