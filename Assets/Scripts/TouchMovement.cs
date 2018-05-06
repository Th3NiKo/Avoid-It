using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour {

	Vector2 startPos;
    public Vector2 direction;
	bool isMoving ;
	float maxVelocity;
	Rigidbody2D rgb;
	void Start () {
		isMoving = false;
		maxVelocity = 10f;
		rgb = GetComponent<Rigidbody2D>();
	}
	
	
	void Update () {
		if(Input.GetMouseButton(0)){
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			Vector3 goTo = new Vector3(pos.x,pos.y,0.0f);
			transform.position = Vector2.MoveTowards(transform.position, goTo, 1f);
			//transform.Translate(goTo);
			transform.position = new Vector3(transform.position.x, transform.position.y, 1.0f);
		}

		
	}
}
