using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public enum GameState{
		Playing, Ended_Lost, Ended_Won
	}

	private static GameManager _instance;

	public int numTotalPuzzlePieces;
	public Text piecesToCollect, piecesCollected, timeRemaining;
	public float timeLeft;

	public static GameState State = GameState.Playing;

	private int puzzlePiecesCollected;
	private int puzzlePiecesToCollect;
	private int numPiecesLevel1;
	private float minutes;
	private float seconds;

	void Start(){
		if (_instance != null) {
			Destroy (this);
			return;
		}
		DontDestroyOnLoad (_instance);
		_instance = this;
		puzzlePiecesCollected = 0;
		puzzlePiecesToCollect = _instance.numTotalPuzzlePieces;
		numPiecesLevel1 = numTotalPuzzlePieces / 2;
		_instance.piecesToCollect.text = "Pieces to Collect: " + _instance.puzzlePiecesToCollect.ToString();
		_instance.piecesCollected.text = "Pieces Collected: " + _instance.puzzlePiecesCollected.ToString ();

		minutes = Mathf.Floor(timeLeft / 60); 
		seconds = timeLeft % 60;
		if(seconds > 59) seconds = 59;
		_instance.timeRemaining.text = "Time Remaining: " + string.Format ("{0:00} : {1:00}", minutes, seconds);
	}

	public void Update() {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("StartingMenu");
		} 
		if (seconds > 0) {
			timeLeft -= Time.deltaTime;
			minutes = Mathf.Floor(timeLeft / 60); 
			if (minutes < 0) {
				minutes = 0;
			}
			seconds = timeLeft % 60;
			if(seconds > 59) seconds = 59;
			_instance.timeRemaining.text = "Time Remaining: " + string.Format ("{0:00} : {1:00}", minutes, seconds);

		}
		else
		{
			LoseTheGame();
		}
	}

	public static void CollectPiece(int numPieces){
		_instance.puzzlePiecesCollected += numPieces; 
		_instance.puzzlePiecesToCollect -= numPieces;
		_instance.piecesToCollect.text = "Pieces to Collect: " + _instance.puzzlePiecesToCollect.ToString();
		_instance.piecesCollected.text = "Pieces Collected: " + _instance.puzzlePiecesCollected.ToString ();
		if (_instance.puzzlePiecesCollected == _instance.numPiecesLevel1) {
			SceneManager.LoadScene ("Level 2");
		}
		if(_instance.puzzlePiecesCollected == _instance.numTotalPuzzlePieces){
			WinTheGame();
		}
	}

	public static void WinTheGame(){
		State = GameState.Ended_Won;
		SceneManager.LoadScene ("FinalPuzzleScene");
	}

	public static void LoseTheGame(){
		State = GameState.Ended_Lost;
		SceneManager.LoadScene ("LosingScene");
	}
}
