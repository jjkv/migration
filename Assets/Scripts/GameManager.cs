using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public enum GameState{
		Playing, Ended
	}

	private static GameManager _instance;

	public int numPuzzlePieces;
//	public Text pointsText;
//	public GameObject winGameGraphics;
	public GameObject looseGameGraphics;

	public static GameState State = GameState.Playing;

	private int points = 0;

	void Start(){
		_instance = this;
		winGameGraphics.SetActive(false);
		looseGameGraphics.SetActive(false);
	}

	public static void AddPoints(int points){
		_instance.points += points;
		_instance.pointsText.text = _instance.points.ToString();
		if(points >= _instance.pointsToWin){
			WinTheGame();
		}
	}

	public static void WinTheGame(){
		State = GameState.Ended;
		_instance.winGameGraphics.SetActive(true);
	}

	public static void LooseTheGame(){
		State = GameState.Ended;
		_instance.looseGameGraphics.SetActive(true);
	}
}
