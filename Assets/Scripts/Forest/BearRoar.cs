using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearRoar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera.main.GetComponent<CameraShake>().ShakeCamera(0.2f, 1f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<Rigidbody2D>().velocity = transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity;
	
	}


}
