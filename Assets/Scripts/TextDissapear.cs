using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextDissapear : MonoBehaviour {

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Color temp = GetComponent<Text>().color;
		GetComponent<Text>().color = new Color(temp.r,temp.g, temp.b, temp.a - 0.02f);
		if(GetComponent<Text>().color.a <= 0.0f){
			Destroy(this.gameObject);
		}
	}
}
