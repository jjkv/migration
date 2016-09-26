﻿using UnityEngine;
using System.Collections;

public class SharkCode : MonoBehaviour {


	public float speed;
	public float bounceForce;

	public bool right;

	private Animator anim;

	public GameObject[] weaknesses;
	private Rigidbody2D rb;

	void Start() {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}


	void Update(){
		if (right) {
			rb.velocity = new Vector2 (speed, rb.velocity.y);
		} else {
			rb.velocity = new Vector2 (-speed, rb.velocity.y);
		}
			
	}

	void OnCollisionEnter2D (Collision2D col) {
		
	}

	void OnTriggerEnter2D ( Collider2D other) {
		if (other.CompareTag ("PlatformA")) {
			right = true;
			anim.SetBool ("Right", right);
		}

		if (other.CompareTag ("PlatformB")) {
			right = false;
			anim.SetBool ("Right", right);
		}

		if (other.CompareTag ("Player")) {
			weaknesses = GameObject.FindGameObjectsWithTag ("shark-weakness");
			Transform weakness = weaknesses [0].transform;
			float distance = Vector3.Distance (weakness.position, other.gameObject.transform.position);
			foreach (GameObject obj in weaknesses) {
				Transform curr = obj.transform;
				float newDist = Vector3.Distance (curr.position, other.gameObject.transform.position);
				if (newDist < distance) {
					weakness = curr;
					distance = newDist;
				}
			}
			float height = other.transform.position.y - weakness.position.y;
			if (height > 0) {
				Debug.Log (bounceForce);
				other.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, bounceForce));
				Destroy (gameObject);		
			} else {
				GameManager.LoseTheGame ();
			}
		}
//
	}


}
