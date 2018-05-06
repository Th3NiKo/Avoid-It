using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class Mobile : MonoBehaviour {

	public GameObject joystick;
	private GameObject joystickCreated;
	bool isCreated;
	void Start () {
		isCreated = false;
	}
	
	
	void Update () {
		/* 
		if(!isCreated){
			if(Input.touchCount > 0){
				if(Input.GetTouch(0).phase == TouchPhase.Began){
					joystickCreated = Instantiate(joystick, Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position),Quaternion.identity);
					joystickCreated.transform.GetChild(0).GetComponent<RectTransform>().position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
				} else if(Input.GetTouch(0).phase == TouchPhase.Ended){
					if(joystickCreated != null){
						Destroy(joystickCreated.gameObject);
					}
				}
			}
		} */
		if(!isCreated){
			if(Input.GetMouseButtonDown(0)){
				joystickCreated = Instantiate(joystick, Camera.main.ScreenToWorldPoint(Input.mousePosition),Quaternion.identity);
				joystickCreated.transform.GetChild(0).GetComponent<RectTransform>().position =Input.mousePosition;
				isCreated = true;
			}
		} else {
				if(Input.GetMouseButtonUp(0)){
				Destroy(joystickCreated.gameObject);
				isCreated = false;
			}
		}


	}
}
