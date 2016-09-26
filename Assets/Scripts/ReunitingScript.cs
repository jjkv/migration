using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReunitingScript : MonoBehaviour {

	public Text congrats;
	public Text instructions;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadScene ("StartingMenu");
		}
	}

	public void Reunite (){
		
		congrats.text = "Jami has successfully reunited with her family!";
		instructions.text = "Press esc to play again.";
	}
}
