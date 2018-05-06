using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	Vector2 Movement;
	Rigidbody2D rgb;
	float timer;
	float speed;
	void Start () {
		timer = 0.0f;
		transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
		speed = Random.Range(4f, 7.0f);
		Movement = new Vector2(-1.0f * speed, 0.0f);
		rgb = GetComponent<Rigidbody2D>();
	}
	
	
	void Update () {
		timer += Time.deltaTime;
		Movement.y = Mathf.Sin(7 * timer);
		rgb.velocity = Movement;
			
	}
}
