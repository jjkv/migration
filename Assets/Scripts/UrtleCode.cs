using UnityEngine;
using System.Collections;

public class UrtleCode : MonoBehaviour {

	public float maxSpeed = 11f;
	bool right = true; //for flipping
	bool ground = false;
	bool climb = false;
	public Transform groundChk;
	float groundRds = 0.2f;
	public float jumpForce = 500f;
	public LayerMask isGround;


	private Animator a;
	private Rigidbody2D r;


	// Use this for initialization
	void Start () {
		a = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.CompareTag ("Ladder") && Input.GetKeyDown (KeyCode.UpArrow)) {
			climb = true;
		}

		if(other.CompareTag("Puzzle Piece")){
			Destroy(other.gameObject);
			GameManager.CollectPiece (1);
		}
	}


	// Update is called once per frame
	void Update () {
		if (ground && Input.GetKeyDown (KeyCode.UpArrow)) {
			a.SetBool("Ground", false);
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
		}
	}
		
	void FixedUpdate () {

		ground = Physics2D.OverlapCircle (groundChk.position, groundRds, isGround);
		a.SetBool ("Ground", ground);
		a.SetFloat ("Vertical Speed", GetComponent<Rigidbody2D> ().velocity.y);
		a.SetBool ("Climb", climb);


		float move = Input.GetAxis ("Horizontal");
		float velY = GetComponent<Rigidbody2D> ().velocity.y;

		a.SetFloat("speed", Mathf.Abs(move));
		GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, velY);

//		if (climb) {
//			a.SetTrigger ("Climbing");
//			climb = false;
//		}

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
