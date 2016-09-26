using UnityEngine;
using System.Collections;

public class SharkCode : MonoBehaviour {


	public float speed;
	public bool right;	

	private Animator anim;


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

	void OnTriggerEnter2D ( Collider2D other) {
		if (other.CompareTag ("PlatformA")) {
			right = true;
			anim.SetBool ("Right", right);
		}

		if (other.CompareTag ("PlatformB")) {
			right = false;
			anim.SetBool ("Right", right);
		}

//		if (other.CompareTag ("Player")) {
//			Destroy (other.gameObject);
//		}
//
	}


}
