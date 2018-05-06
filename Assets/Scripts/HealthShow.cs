using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthShow : MonoBehaviour {

	public GameObject Image;
	void Start () {
		
	}
	

	void Update () {
		
	}

	public void AddHealth(){
		Vector3 pos = transform.GetChild(transform.childCount - 1).position;
		pos.x += 40;
		Instantiate(Image, pos, Quaternion.identity);
	}

	public void RemoveHealth(){
		if(transform.childCount > 0){
			Destroy(transform.GetChild(transform.childCount - 1).gameObject);
		}
	}
}
