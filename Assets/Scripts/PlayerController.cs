using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed, jumpForce;
	private Rigidbody rb;
	private bool canJump;
	GameObject [] coins;
	int total_coins;
	public int score;

	private float currentRotation;
	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

		//track coins
		total_coins = 0;
		score = 0;
		coins = GameObject.FindGameObjectsWithTag("coin");
		foreach(GameObject coin in coins){
			Debug.Log("I am a coin!");
			total_coins++;
		}
	}

	//movement
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);

		if (canJump) {
			canJump = false;
			Vector3 jump = new Vector3 (0.0f, jumpForce, 0.0f);
			rb.AddForce(jump);
		}
	}


	void Update(){
		if (Input.GetKeyUp ("space")) {
			canJump = true;
		}	
	}

	//collect coins
	void OnTriggerEnter(Collider other){
		if (other.CompareTag("coin")){
			Destroy(other.gameObject);
			score++;
			Debug.Log("Score : " + score);
			if(score >= total_coins){
				Debug.Log("You win!");
			}
		}
	}
}
