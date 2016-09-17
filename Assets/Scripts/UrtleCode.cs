using UnityEngine;
using System.Collections;

public class UrtleCode : MonoBehaviour {

	public float maxSpeed = 11f;
	bool right = true; //for flipping
	Animator a;


	// Use this for initialization
	void Start () {
		a = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");
		float velY = GetComponent<Rigidbody2D> ().velocity.y;

		a.SetFloat("speed", Mathf.Abs(move));
		GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, velY);

		if(move > 0 && !right) {
			Flip();
		}

		else {
			if(move < 0 && right)
				Flip();
		}
					
	}

	void Flip(){
		right = !right;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
			
}
