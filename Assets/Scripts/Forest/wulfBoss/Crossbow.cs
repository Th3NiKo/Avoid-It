using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour {

	public GameObject bolt;
	Vector3 wolf;
	float liveTimer;
	
	float speedUp;
	bool hasBumped;
	bool goUp;
	Quaternion min =  Quaternion.Euler(new Vector3(0f, 0f, -20f));
	Quaternion max = Quaternion.Euler( new Vector3(0f, 0f, 20f));
	Quaternion rotation;	
	float timeToLive;
	float rotationTimer = 0.0f;
	bool shooted;
	bool playerTook;
	void Start () {
		wolf = GameObject.Find("Forest_8(Clone)").transform.position;
		transform.localScale = new Vector3(0.1f, 0.1f, 1f);
		hasBumped = false;
		goUp = true;
		rotation = transform.rotation;
		liveTimer = 0f;
		speedUp = 1.0f;
		timeToLive = Random.Range(2f, 3.5f);
		playerTook = false;
		shooted = false;
	}
	
	// Update is called once per frame
	void Update () {
		//*******************
		//Bumping and waiting
		//*******************
		if(!playerTook){
			liveTimer += Time.deltaTime;
			speedUp += 1.1f;
			if(!hasBumped){
				if(transform.localScale.x <= 1.0f){
					transform.localScale = new Vector3(transform.localScale.x + 0.04f, transform.localScale.y + 0.04f, 1.0f);
				} else {
					hasBumped = true;
				}
			} else {
				if(goUp){
					//transform.Rotate(new Vector3(0.0f, 0.0f, 1f));
					rotation.z += Quaternion.Euler (new Vector3 (0f, 0f, (100f + speedUp) * Time.deltaTime)).z;
					if(rotation.z >= max.z) goUp = false;
				} else {
					//transform.Rotate(new Vector3(0.0f, 0.0f,-1f));
					rotation.z -= Quaternion.Euler (new Vector3 (0f, 0f, (100f + speedUp) * Time.deltaTime)).z;
					if(rotation.z <= min.z) goUp = true;
				}
				transform.rotation = rotation;
			}
			//spriteR.color = new Color(spriteR.color.r, spriteR.color.g, spriteR.color.b,spriteR.color.a - 0.004f);
			if(liveTimer >= timeToLive){
				Destroy(this.gameObject);
			}
		} else {

		//*********************
		//Player takes crossbow
		//*********************
		GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f,1f);
		rotationTimer += Time.deltaTime;
		
		if(rotationTimer <= 0.5f){
			wolf = GameObject.Find("Forest_8(Clone)").transform.position;
			transform.right = wolf - transform.position;
		} else {
			if(!shooted){
				Instantiate(bolt, transform.position, Quaternion.identity);
				Invoke("DestroyMe", 1f);
				shooted = true;
			}
		
		}
			
		} 
	}

	void DestroyMe(){
		Destroy(this.gameObject);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player"){
			playerTook = true;
		}
	}
}
