using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public enum GameState{
		Playing, Ended
	}

	private static GameManager _instance;

	public int numTotalPuzzlePieces;
	public Text piecesToCollect, piecesCollected;
	//public GameObject winGameGraphics;
	//public GameObject looseGameGraphics;

	public static GameState State = GameState.Playing;

	private int puzzlePiecesCollected;
	private int puzzlePiecesToCollect;

	void Start(){
		_instance = this;
		//winGameGraphics.SetActive(false);
		//looseGameGraphics.SetActive(false);
		puzzlePiecesCollected = 0;
		puzzlePiecesToCollect = _instance.numTotalPuzzlePieces;
		_instance.piecesToCollect.text = "Pieces to Collect: " + _instance.puzzlePiecesToCollect.ToString();
		_instance.piecesCollected.text = "Pieces Collected: " + _instance.puzzlePiecesCollected.ToString ();
	}

	public static void CollectPiece(int numPieces){
		_instance.puzzlePiecesCollected += numPieces; 
		_instance.puzzlePiecesToCollect -= numPieces;
		_instance.piecesToCollect.text = "Pieces to Collect: " + _instance.puzzlePiecesToCollect.ToString();
		_instance.piecesCollected.text = "Pieces Collected: " + _instance.puzzlePiecesCollected.ToString ();
		//		if(_instance.puzzlePiecesCollected == _instance.numTotalPuzzlePieces){
		//			WinTheGame();
		//		}
	}

	//	public static void WinTheGame(){
	//		State = GameState.Ended;
	//		_instance.winGameGraphics.SetActive(true);
	//	}

	//	public static void LooseTheGame(){
	//		State = GameState.Ended;
	//		_instance.looseGameGraphics.SetActive(true);
	//	}
}
