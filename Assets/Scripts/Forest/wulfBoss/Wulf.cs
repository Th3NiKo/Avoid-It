using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Chasing		0
//moon			1
//shooting		2
//wolfes		3

public class Wulf : MonoBehaviour {

	public GameObject Danger;
	public GameObject Moon;
	public GameObject Hunter;
	public GameObject Wolf;
	public GameObject Crossbow;
	GameObject hunterCreated;

	float minCooldown;
	float maxCooldown;
	float actualCooldown;
	float timerCooldown;
	float timer;

	int actualState;
	int stateNumber;

	float speed;

	Vector3 startingPosition;
	Rigidbody2D rgb;
	SpriteRenderer spr;
	bool goDown;
	bool isHunter;

	//Killling boss
	int health;
	float crossbowTimer;
	float crossbowCooldown;

	float lastState;
	void Start () {
		rgb = GetComponent<Rigidbody2D>();
		spr = GetComponent<SpriteRenderer>();
		timer = 0.0f;
		goDown = false;
		speed = 5.7f;
		stateNumber = 4;
		actualState = 0;
		timerCooldown = 0.0f;
		minCooldown = 4f;
		maxCooldown = 6f;
		actualCooldown = Random.Range(minCooldown, maxCooldown);
		startingPosition = this.transform.position;
		isHunter = false;
		health = 5;
		crossbowTimer = 0f;
		lastState = 0;
		crossbowCooldown = Random.Range(8f, 10f);

	}
	
	
	void Update () {
		timerCooldown += Time.deltaTime;
		if(timerCooldown >= actualCooldown){
			lastState = actualState;
			actualState = Random.Range(0,stateNumber);
			
			//Through states resets
			if(actualState == 1) timer = 0.0f;
			if(hunterCreated != null) Destroy(hunterCreated.gameObject);
			isHunter = false;


			//Reseting timer
			timerCooldown = 0.0f;
			actualCooldown = Random.Range(minCooldown, maxCooldown);
			StartCoroutine(WaitTime(0.5f)); //Wait some time between states
		}

		switch(actualState){
			case 0: //Chasing player
				Vector3 whereToGo = GameObject.Find("Player").transform.position;
				rgb.velocity = new Vector2(whereToGo.x - transform.position.x, whereToGo.y - transform.position.y).normalized * 5.0f;
			break;

			case 1: //Throwing moon
	
				if(Mathf.Abs(transform.position.x - startingPosition.x) <= 0.1f){
					MoveUpDown();
					timer += Time.deltaTime;
					if(timer >= 1.0f){
						float moonX = Random.Range(0.1f, 0.7f);
						if(Danger != null){
							GameObject tempDanger = Instantiate(Danger, Camera.main.ViewportToWorldPoint(new Vector3(moonX, 0.5f, 1.0f)), Quaternion.identity);
							tempDanger.GetComponent<IconShow>().setLifeTime(0.65f);
						}
						StartCoroutine(CreateMoon(moonX, 0.65f));
						timer = 0.0f;
					}
				} else { //Wait for comming to start
					GoToStart();
					timerCooldown = 0.0f;
				}

			break;

			case 2: //Hunter appears and shoot wolf
			if(Mathf.Abs(transform.position.x - startingPosition.x) <= 0.1f){
				MoveUpDown();
				if(lastState == 2) isHunter = true;
				if(!isHunter){
					timer+= Time.deltaTime;
					hunterCreated = Instantiate(Hunter,Camera.main.ViewportToWorldPoint(new Vector3(0.2f, 0.5f, 1f)), Quaternion.identity);
					isHunter = true;
				} else { //Hunter exist on scene
				}
			} else {
				GoToStart();
				timerCooldown = 0.0f;
			}
			break;
			
			case 3: //Wolf rushing
			if(Mathf.Abs(transform.position.x - startingPosition.x) <= 0.1f){
				MoveUpDown();
				timer += Time.deltaTime;
				if(timer >= 0.7f){
					float wolfY = Random.Range(0.06f, 0.94f);
					GameObject tempWolf = Instantiate(Wolf, Camera.main.ViewportToWorldPoint(new Vector3(1.2f, wolfY, 1f)), Quaternion.identity);
					tempWolf.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.0f,0.0f).normalized * 18f;
					timer = 0.0f;
				}
			} else {
				GoToStart();
				timerCooldown = 0.0f;
			}
			break;

		}

		//CrossBow
		crossbowTimer += Time.deltaTime;
		if(crossbowTimer >= crossbowCooldown){
			CrossbowCreate();
			crossbowTimer = 0.0f;
			crossbowCooldown = Random.Range(8f, 10f);
		}
		isDead();
	}


	void GoToStart(){
		rgb.velocity = new Vector2(startingPosition.x - transform.position.x, startingPosition.y - transform.position.y).normalized * speed;
	}
	void MoveUpDown(){
		Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
		if(!goDown){
			rgb.velocity = new Vector2(0f, speed);
			if(pos.y >= 1.0f) goDown = true;
		} else {
			rgb.velocity = new Vector2(0f, -speed);
			if(pos.y <= 0.0f) goDown = false;
		}
	}

	IEnumerator CreateMoon(float x, float waitTime){
		yield return new WaitForSeconds(waitTime);
		Vector3 position = new Vector3(x, 1.2f, 1.0f);
		GameObject tempMoon = Instantiate(Moon, Camera.main.ViewportToWorldPoint(position), Quaternion.identity);
		tempMoon.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -7.5f).normalized * 16f;
	}

	IEnumerator WaitTime(float waitTime){
		yield return new WaitForSeconds(waitTime);
	}

	void CrossbowCreate(){
		float tempX = Random.Range(0.1f, 0.80f);
		float tempY = Random.Range(0.1f, 0.80f);
		Vector3 tempPos = new Vector3(tempX, tempY, 1.0f);
		Instantiate(Crossbow, Camera.main.ViewportToWorldPoint(tempPos), Quaternion.identity);
	}

	void isDead(){
		if(health <= 0){
			if(hunterCreated != null) Destroy(hunterCreated);
			Destroy(this.gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Bullet"){
			Color c = spr.color;
			StartCoroutine(ChangeColor(1f, 0f, 0f , 0));
			StartCoroutine(ChangeColor(c.r, c.g, c.b, c.a));
			Destroy(other.gameObject);
			health--;
		}
	}

	IEnumerator ChangeColor(float r, float g, float b, float waitTime){
		yield return new WaitForSeconds(waitTime);
		spr.color = new Color(r, g, b, spr.color.a);
	}
}
