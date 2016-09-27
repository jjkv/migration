﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public enum GameState{
		Playing, Ended_Lost, Ended_Won
	}

	private static GameManager _instance;

	public int numTotalPuzzlePieces;
	public Text piecesCollected, timeRemaining, seaweedText;
	public float timeLeft;

	public static GameState State = GameState.Playing;

	private int puzzlePiecesCollected;
	private int numPiecesPerLevel;
	private int seaweedCollected;
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
		numPiecesPerLevel = numTotalPuzzlePieces / 2;
		_instance.piecesCollected.text = " : " + _instance.puzzlePiecesCollected.ToString () +" / " +
			_instance.numPiecesPerLevel.ToString();

		seaweedCollected = 0;

		minutes = Mathf.Floor(timeLeft / 60); 
		seconds = timeLeft % 60;
		if(seconds > 59) seconds = 59;
		_instance.timeRemaining.text = "Time Left: " + string.Format ("{0:00} : {1:00}", minutes, seconds);
	}

	public void Update() {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("StartingMenu");
		} 
		if (seconds > 0 || minutes > 0) {
			timeLeft -= Time.deltaTime;
			minutes = Mathf.Floor(timeLeft / 60); 
			if (minutes < 0) {
				minutes = 0;
			}
			seconds = timeLeft % 60;
			if(seconds > 59) seconds = 59;
			_instance.timeRemaining.text = "Time Left: " + string.Format ("{0:00} : {1:00}", minutes, seconds);

		}
		else
		{
			LoseTheGame();
		}
	}



	public static void CollectPiece(int numPieces){
		_instance.puzzlePiecesCollected += numPieces; 
		_instance.piecesCollected.text = " : " + _instance.puzzlePiecesCollected.ToString () +" / " +
			_instance.numPiecesPerLevel.ToString();
		if (Application.loadedLevelName == "Level 1" && _instance.puzzlePiecesCollected == _instance.numPiecesPerLevel) {
			SceneManager.LoadScene ("Level 2");
		}
		if (Application.loadedLevelName == "Level 2" && _instance.puzzlePiecesCollected == _instance.numPiecesPerLevel) {
			WinTheGame();
		}
	}



	public static void CollectSeaweed(){
		_instance.seaweedCollected++;
		if (Application.loadedLevelName == "Level 1" && _instance.seaweedCollected == 1) {
			//_instance.seaweedText.text = "Seaweed adds 10 seconds!";
			//StartCoroutine(DisableTextAfter(3.0));
			//_instance.seaweedText.text = "";
		}

	}

	public static void WinTheGame(){
		State = GameState.Ended_Won;
		SceneManager.LoadScene ("FinalPuzzleScene");
	}

	public static void LoseTheGame(){
		State = GameState.Ended_Lost;
		if (Application.loadedLevelName == "Level 1") {
			SceneManager.LoadScene ("LosingScene");
		}
		else if (Application.loadedLevelName == "Level 2") {
			SceneManager.LoadScene ("LosingScene2");
		}

	}
//
//	IEnumerator DisableTextAfter(float waitTime){
//		return yield new WaitForSeconds(waitTime);			
//	}


}