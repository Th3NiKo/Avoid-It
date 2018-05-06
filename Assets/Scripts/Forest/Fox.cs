using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour {

	// Use this for initialization
	SpriteRenderer spr;
	bool goDown;
	void Start () {
		spr = GetComponent<SpriteRenderer>();
		goDown = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(goDown){
			spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, spr.color.a - 0.01f);
			if(spr.color.a <= 0f){
				Invoke("GoUp", 0.5f);
			}
		} else {
			spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, spr.color.a + 0.01f);
			if(spr.color.a >= 0.4f){
				goDown = true;
			}
		}
	}

	void GoUp(){
		goDown = false;
	}
}
