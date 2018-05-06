using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextShow : MonoBehaviour {

public Text textObject;
	void Start () {
		
	}
	
	
	void Update () {
		
	}


	public void CreateText(Vector3 position, Color color, int size, string text){
		Text tempText = textObject;
		tempText.text = text;
		tempText.color = color;
		tempText.fontSize = size;
		GameObject temp = Instantiate(tempText, position, Quaternion.identity).gameObject;

		temp.transform.SetParent(GameObject.Find("TextCanvas").transform);
		temp.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
		temp.transform.position = position;
	}


}
