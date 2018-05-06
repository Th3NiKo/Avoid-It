using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	private void OnTriggerEnter2D(Collider2D other) {
		Destroy(other.gameObject);
	}
}
