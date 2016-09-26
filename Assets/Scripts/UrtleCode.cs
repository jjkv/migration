using UnityEngine;
using System.Collections;

public class UrtleCode : MonoBehaviour {

	enum Movement{Normal, Climb}
	Movement movement = Movement.Normal;
		
	public float maxSpeed = 9f;
	public float jumpForce = 500f;
	float groundRds = 0.2f;

	bool ground = false;
	bool climb = false;
	bool right = true;
	private Collider2D ignored;
	public Transform groundChk;
	public LayerMask isGround;

	private Animator anim;
	private Rigidbody2D rb;
	private GameObject manager; 
	private GameManager managerScript;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		manager = GameObject.Find ("GameManager");
		managerScript = manager.GetComponent<GameManager> ();

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Ladder")) {
			climb = true;
		}
		if (other.CompareTag("Puzzle Piece")){
			other.gameObject.GetComponent<PuzzlePieceCode>().collected = true;
			Destroy(other.gameObject);
			GameManager.CollectPiece(1);
		}
		if (other.CompareTag ("Seaweed")) {
//			GameObject manager = GameObject.Find ("GameManager");
//			GameManager managerScript = manager.GetComponent<GameManager> ();
			managerScript.timeLeft += 10;
			Debug.Log (managerScript.timeLeft);
			Destroy (other.gameObject);
		}

		if (other.CompareTag ("Border")) {
//			managerScript.LoseTheGame ();
			//end game
			//set turtle gravity to 0
		}
	}

	void OnCollisionStay2D (Collision2D col) {
		if (col.collider.tag == "Platform") {
			if (movement == Movement.Climb && Input.GetKey (KeyCode.DownArrow)) {
				Debug.Log ("open");
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D> (), col.collider);
				ignored = col.collider;
			}
		}
	}
//
//	void OnCollisionExit2D (Collision2D col) {
//		if (col.collider.tag == "Platform") {
//			if (movement == Movement.Climb && Input.GetKey (KeyCode.DownArrow)) {
//				Debug.Log ("got out");
//				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D>(), col.collider, false);
//			}
//		}
//	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.CompareTag("Ladder")) {
			climb = true;
		} 
	}
	
	void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag ("Ladder")) {
			anim.SetBool ("Climb", false);
			climb = false;
			if (ignored) {
				Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D> (), ignored, false);
				ignored = null;
			}
			rb.gravityScale = 1;
			movement = Movement.Normal;
		} 
	}

	// Update is called once per frame
	void Update () {
		if (climb && (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.DownArrow))) {
			movement = Movement.Climb;
			anim.SetBool ("Climb", climb);
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			rb.gravityScale = 1;
			movement = Movement.Normal;
			anim.SetBool ("Ground", false);
			if (ground) {
				rb.AddForce (new Vector2 (0, jumpForce));
			}
		} 
	}

	// Update Physics 
	void FixedUpdate () {
		ground = Physics2D.OverlapCircle (groundChk.position, groundRds, isGround);
		anim.SetBool ("Ground", ground);
		switch (movement) {
			case Movement.Normal:
				Move();
				break;
			case Movement.Climb:
				Climb();
				break;
		}			
	}

	void Flip(){
		right = !right;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	void Climb() {
		rb.gravityScale = 0;
//		GameObject urtle = GameObject.FindGameObjectWithTag ("Player");
//		Debug.Log(urtle.transform);
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate (Vector2.up * Time.deltaTime * maxSpeed);
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate (Vector2.down * Time.deltaTime * maxSpeed);
		} else if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.LeftArrow)) {
			movement = Movement.Normal;
			anim.SetBool ("Climb", false);
			climb = false;
			rb.gravityScale = 1;
		}
	}


	void Move() {
		rb.gravityScale = 1;
		anim.SetFloat ("Vertical Speed", rb.velocity.y);
		float move = Input.GetAxis ("Horizontal");
		float velY = rb.velocity.y;

		anim.SetFloat("Speed", Mathf.Abs(move));
		rb.velocity = new Vector2(move * maxSpeed, velY);

		if(move > 0 && !right) {
			Flip();
		}

		else if(move < 0 && right) {
			Flip();
		}
	}
		
}
