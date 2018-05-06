using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour {

	
	public GameObject[] Normal; // 80% 1 point for avoid
	public GameObject[] Average; // 15% 2 points for avoid
	public GameObject[] Rare; // 5% 4 points for avoid
	public GameObject[] Boss;
	public GameObject DangerSign;
	public int howManyPointsToBoss;
	GameObject pointsManager;
	ObstaclesCleaner pointCounter;
	private float spawnTimer;
	public float minCooldown;
	public float maxCooldown;
	private float actualCooldown;
	bool bossSpawned;
	Vector3 BossPosition;
	BoostsManager boosts;
	MusicForest music;

	void Start () {
		spawnTimer = 0.0f;
		actualCooldown = Random.Range(minCooldown, maxCooldown);
		pointsManager = GameObject.Find("ObstaclesCleaner");
		pointCounter = pointsManager.GetComponent<ObstaclesCleaner>();
		bossSpawned = false;
		BossPosition = new Vector3(0.85f, 0.5f, 1f);
		music = GameObject.Find("Music").GetComponent<MusicForest>();
		boosts = GameObject.Find("BoostsManager").GetComponent<BoostsManager>();
	}
	
	
	void Update () {
		if(pointCounter.GetPoints() <= howManyPointsToBoss){
			spawnTimer += Time.deltaTime;
			//Create Obstacle
			if(spawnTimer >= actualCooldown){
				//Choose which one type
				float whichOneType = Random.Range(0.0f, 1.0f);
				int whichOneObject;
				float positonY = Random.Range(0.03f, 0.93f);
				Vector3 position = new Vector3(1.2f, positonY, 1.0f);
				float rotation = Random.Range(0, 359);
				float speed = Random.Range(1.3f, 5.0f);
				GameObject justCreated;
				if(whichOneType <= 0.85f){ 
					//Normal 
					whichOneObject = Random.Range(0,Normal.Length);
					justCreated = Instantiate(Normal[whichOneObject], Camera.main.ViewportToWorldPoint(position),Quaternion.identity);
					justCreated.transform.eulerAngles = new Vector3(justCreated.transform.eulerAngles.x, justCreated.transform.eulerAngles.y, rotation);

				} else if(whichOneType <= 0.95f){
					
					//Average
					whichOneObject = Random.Range(0,Average.Length);
					justCreated = Instantiate(Average[whichOneObject], Camera.main.ViewportToWorldPoint(position),Quaternion.identity);
			
				} else { 
					//Rare
					whichOneObject = Random.Range(0,Rare.Length);
					justCreated = Instantiate(Rare[whichOneObject], Camera.main.ViewportToWorldPoint(position),Quaternion.identity);
				}
				justCreated.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0.0f);

				spawnTimer = 0.0f;
				actualCooldown = Random.Range(minCooldown, maxCooldown);
			}
		} else { //Got enough points for boss
			if(!bossSpawned){ //Spawn it once
				Object[] allObjects = Object.FindObjectsOfType(typeof(GameObject));
				foreach(object obj in allObjects){
					GameObject g = (GameObject) obj;
					if(g.tag == "Obstacle"){
						Destroy(g);
					}
				}
				if(DangerSign != null) Instantiate(DangerSign, Camera.main.ViewportToWorldPoint(BossPosition), Quaternion.identity);
				Camera.main.GetComponent<CameraShake>().ShakeCamera(1f, 1f, 2f);
				boosts.TurnPoints(false);
				Invoke("createBoss", 2f);
				bossSpawned = true;
			}
		}

	}

	void createBoss(){
		int whichOne = Random.Range(0,Boss.Length);
		music.PlayBossMusic();
		GameObject BossObject = Instantiate(Boss[whichOne], Camera.main.ViewportToWorldPoint(BossPosition),Quaternion.identity);
	}
	

}
