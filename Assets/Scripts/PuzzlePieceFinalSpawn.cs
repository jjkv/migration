using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzlePieceFinalSpawn : MonoBehaviour {

	public GameObject[] piecePrefabs;
	public GameObject[] emptyPlaces;
	public GameObject fullPuzzlePrefab;
	public Text instructions;
	public Text finalText;
	public float speedOfPiece;

	private GameObject[] piecesOnScreen;
	private bool isCreated = false;

	private int pieceNum = 0;

	void Start() {
		piecesOnScreen = new GameObject[piecePrefabs.Length];

		if(GameManager.State != GameManager.GameState.Ended_Won){
			return;
		}
		for (int i=0; i < piecePrefabs.Length; i++){
			float screenwidth = Screen.width;
			float screenheight = Screen.height;
			Vector3 screenPosition = new Vector3 (Random.Range(0, screenwidth), Random.Range(0, screenheight), 10);
			Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(screenPosition); 
			piecesOnScreen[i] = (GameObject) Instantiate(piecePrefabs[i], spawnPosition, Quaternion.identity);
		}
		instructions.text = "Keep clicking the screen to figure out where Jami's family is waiting.";
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			instructions.text = "";
			if (pieceNum == piecePrefabs.Length && isCreated == false) {
				Vector3 spawnPosition = new Vector3 (0, 0, 0);
				Instantiate (fullPuzzlePrefab, spawnPosition, Quaternion.identity);
				isCreated = true;

				for (int i = 0; i < piecesOnScreen.Length; i++) {
					Destroy (piecesOnScreen [i]);
				}
				finalText.text = "Jami's family is waiting for her in a tree house (odd for sea turtles...). Press return to join them!";
			}
			if (pieceNum < piecePrefabs.Length) {
				float step = speedOfPiece * Time.deltaTime;
				Vector3 finalPosition = emptyPlaces [pieceNum].gameObject.transform.position;
				piecesOnScreen [pieceNum].gameObject.transform.position = 
					Vector3.MoveTowards (piecesOnScreen [pieceNum].gameObject.transform.position, finalPosition, step);
				pieceNum++;
			}

		}
		if (isCreated==true && Input.GetKeyDown(KeyCode.Return)) {
			SceneManager.LoadScene ("ReunitingScene");
		}
		if (Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadScene ("StartingMenu");
		}
	}
		

}
	


	