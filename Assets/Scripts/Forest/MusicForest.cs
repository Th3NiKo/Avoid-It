using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MusicForest : MonoBehaviour {

	public AudioClip boss;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayBossMusic(){
		this.GetComponent<AudioSource>().clip = boss;
		this.GetComponent<AudioSource>().Play();
	}
}
