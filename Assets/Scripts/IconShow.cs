using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconShow : MonoBehaviour {

	public float lifeTime;
	float lifeTimer;
	void Start () {
		lifeTimer = 0.0f;
	}
	
	
	void Update () {
		lifeTimer += Time.deltaTime;
		transform.localScale = new Vector3(transform.localScale.x + 0.05f, transform.localScale.y +0.05f, 1.0f);
		if(lifeTimer >= lifeTime){
			Destroy(this.gameObject);
		}
	}

	public void setLifeTime(float lifeTimeSet){
		lifeTime = lifeTimeSet;
	}
}
