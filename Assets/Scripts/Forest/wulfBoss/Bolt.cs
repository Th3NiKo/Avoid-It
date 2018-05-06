using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour {

	// Use this for initialization
	Vector3 wolf;
	Rigidbody2D rgb;
	void Start () {
		wolf = GameObject.Find("Forest_8(Clone)").transform.position;
		rgb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		rgb.velocity = new Vector2(wolf.x - transform.position.x, wolf.y - transform.position.y).normalized * 18f;
		transform.right = wolf - transform.position;
	}

	void FixedUpdate() {
		wolf = GameObject.Find("Forest_8(Clone)").transform.position;
	}
}
