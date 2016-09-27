using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LosingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (Application.loadedLevelName == "LosingScene") {
				SceneManager.LoadScene ("StartingMenu");
			}
			else if (Application.loadedLevelName == "LosingScene2") {
				SceneManager.LoadScene ("Level 2");
			}
		}
	}
}
