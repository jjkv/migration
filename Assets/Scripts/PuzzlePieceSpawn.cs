using UnityEngine;
using System.Collections;

public class PuzzlePieceSpawn : MonoBehaviour {
	public GameObject[] puzzlePieces;
	public GameObject[] emptyLocations;


	// Use this for initialization
	void Start () {
		for (int i = 0; i < puzzlePieces.Length; i++)
		{
			Vector3 spawnPosition = emptyLocations [i].gameObject.transform.position;
			Instantiate(puzzlePieces[i], spawnPosition, Quaternion.identity);

		}
	}
	
	// Update is called once per frame
	void Update () {
	 
	}
}
