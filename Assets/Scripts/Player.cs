using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour {

    public float maxVelocity;
	public Material redTrail;
	public Material whiteTrail;
	int hp;

	bool targetable;

	HealthShow hpShow;

	 Rigidbody2D rgb;
	 TrailRenderer tr;

	void Awake () {
		hp = 3;
		targetable = true;
		rgb = GetComponent<Rigidbody2D>();
		hpShow = GameObject.Find("Health").GetComponent<HealthShow>();
		tr = GetComponent<TrailRenderer>();
	}
	

	
	void Update () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		//float h = CrossPlatformInputManager.GetAxis("Horizontal");
		//float v = CrossPlatformInputManager.GetAxis("Vertical");
		Vector3 goTo = new Vector3(h,v,0.0f).normalized * maxVelocity * Time.deltaTime;
		if(h != 0f || v != 0f){
			transform.Translate(goTo);
		} else {
			rgb.velocity = Vector3.zero;
		}
		KeepPlayerOnScreen();
	}

	void KeepPlayerOnScreen(){
		var pos = Camera.main.WorldToViewportPoint(transform.position);
 		pos.x = Mathf.Clamp(pos.x, 0.01f, 0.98f);
 		pos.y = Mathf.Clamp(pos.y, 0.02f, 0.98f);
 		transform.position = Camera.main.ViewportToWorldPoint(pos);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Obstacle"){
			if(targetable){
				GotHitted();
				if(hp <= 0){
					 SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				}
			}
		}
	}


	void GotHitted(){
		
		//Take down hp
		hp--;
		//Take down image hp
		hpShow.RemoveHealth();
		Camera.main.GetComponent<CameraShake>().ShakeCamera(0.1f, 1f, 1f);
		//Get Player to center
		var pos = Camera.main.WorldToViewportPoint(transform.position);
		pos.x = 0.1f;
		pos.y = 0.5f;
		transform.position = Camera.main.ViewportToWorldPoint(pos);
		//Give Player untargetable
		targetable = false;
		tr.material = whiteTrail;
		ChangeColor(1,1,1);
		Invoke("MakeTargetable", 2.5f);

	}

	void MakeTargetable(){
		targetable = true;
		ChangeColor(1,0,0);
		tr.material = redTrail;
	}

	void ChangeColor(float r, float g, float b){
		SpriteRenderer spr = GetComponent<SpriteRenderer>();
		spr.color = new Color(r, g, b, 1);
	}


	
}
