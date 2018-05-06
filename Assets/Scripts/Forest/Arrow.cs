using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	Vector3 origin;
	Vector3 whereToGo;

	Rigidbody2D rgb;
	Vector3 lookVector;
	void Start () {
		rgb = GetComponent<Rigidbody2D>();
		origin = transform.position;
		whereToGo = GameObject.Find("Player").transform.position;
		transform.right = whereToGo - transform.position;

	
		
	}
	
	void Update () {
		rgb.velocity = new Vector2(whereToGo.x - origin.x, whereToGo.y - origin.y);
		
		
	}
}
