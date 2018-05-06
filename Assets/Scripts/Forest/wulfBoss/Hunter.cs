using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour {

	GameObject wolf;
	public GameObject bullet;
	float cooldown;
	float timer;
	float speed;
	bool goDown;

	Rigidbody2D rgb;
	void Start () {
		timer = 0.0f;
		cooldown = 0.3f;
		speed = 6f;
		goDown = false;
		rgb = GetComponent<Rigidbody2D>();
	}
	
	
	void Update () {
		MoveUpDown();
		timer += Time.deltaTime;
		if(timer >= cooldown){
			Vector3 position = transform.position;
			GameObject tempbullet1 = Instantiate(bullet,new Vector3(position.x, position.y + 0.4f, position.z),Quaternion.identity );
			GameObject tempbullet2 = Instantiate(bullet,new Vector3(position.x, position.y - 0.4f, position.z),Quaternion.identity );
			tempbullet1.GetComponent<Rigidbody2D>().velocity = new Vector2(8f, 0.0f);
			tempbullet2.GetComponent<Rigidbody2D>().velocity = new Vector2(8f, 0.0f);
			timer = 0.0f;
			cooldown = Random.Range(0.15f, 0.3f);
		}
	}

	void MoveUpDown(){
		Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
		if(!goDown){
			rgb.velocity = new Vector2(0f, speed);
			
		} else {
			rgb.velocity = new Vector2(0f, -speed);
			
		}
		if(pos.y >= 1.0f) goDown = true;
		if(pos.y <= 0.0f) goDown = false;
	}
}
