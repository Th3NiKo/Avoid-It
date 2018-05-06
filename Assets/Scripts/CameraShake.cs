using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	float shake;
	bool shaking;

	float _value;
	float _decreaseRate;
	void Start () {
		shake = 0.0f;
		shaking = false;
	}
	
	void Update () {
		if(shake >= 0){
			Camera.main.transform.localPosition = Random.insideUnitSphere * _value;
			shake -= Time.deltaTime * _decreaseRate;
		} else {
			_value = 0;
			_decreaseRate = 0;
		}

	}


	public void ShakeCamera(float value, float decreaseRate, float howLong){
		
		_value = value;
		_decreaseRate = decreaseRate;
		shake = howLong;
	}
}
