using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInstanceManager : MonoBehaviour {

	public CoinManager manager;

	// Use this for initialization
	void Start () {
		//manager = GameObject.Find ("CoinManager");
	}

	void OnTriggerEnter(Collider other){
		manager.score++;
		Destroy (this);
		Debug.Log ("Got one!  Score: " + manager.score);
	}
	
}
