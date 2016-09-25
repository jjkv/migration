using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneScript : MonoBehaviour {

	public Button StartButton;

	// Use this for initialization
	void Start () {
		StartButton.onClick.AddListener (() =>
			SceneManager.LoadScene ("StoryScene"));
		//change above once we bring the code together
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
