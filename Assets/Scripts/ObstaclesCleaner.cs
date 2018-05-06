using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstaclesCleaner : MonoBehaviour {

	public Text points;
	int pointsValue;
	Outline outLine;
	float shakeTimer;

	void Start(){
		pointsValue = 0;
		shakeTimer = -1f;
		outLine = points.GetComponent<Outline>();
	}
	void Update() {
		if(shakeTimer >= 0.0f){
			outLine.effectDistance = new Vector2(3 * Mathf.Sin(shakeTimer) + 1, -3 * Mathf.Sin(shakeTimer) - 1);
		} else {
			outLine.effectDistance = new Vector2(1, -1);
		}
		points.text = pointsValue.ToString();
		shakeTimer -= Time.deltaTime;
	}
	private void OnTriggerEnter2D(Collider2D other) {
		pointsValue += 15;
		shakeTimer = 1.0f;

		Destroy(other.gameObject);
	}


	public void AddPoints(int howMany){
		pointsValue += howMany;
		shakeTimer = 1.0f;
	}

	public int GetPoints(){
		return pointsValue;
	}
	


}
