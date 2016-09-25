using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryLineScript : MonoBehaviour {
	public Text storyText;
	public Image turtleFam, turtleInd, puzzlePiece;
	private int counter;


	// Use this for initialization
	void Start () {
		storyText.text = "Sea Turtles seasonally migrate to warmer waters...";
		counter = 1;
		turtleFam.enabled = !turtleFam.enabled;
		turtleInd.enabled = !turtleInd.enabled;
		puzzlePiece.enabled = !puzzlePiece.enabled;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (counter == 1) {
				storyText.text = "...Sometimes their journeys take them hundreds and even thousands of miles.";
				counter++;
			} else if (counter == 2) {
				storyText.text = "Unfortunately Jami's family left while she was asleep.";
				counter++;
				turtleFam.enabled = !turtleFam.enabled;
				turtleInd.enabled = !turtleInd.enabled;
			} else if (counter == 3) {
				storyText.text = "Help Jami collect puzzle pieces to figure out where her family is waiting for her.";
				turtleFam.enabled = !turtleFam.enabled;
				turtleInd.enabled = !turtleInd.enabled;
				puzzlePiece.enabled = !puzzlePiece.enabled;
				counter++;
			} else if (counter == 4) {
				storyText.text = "Unfortunately a young turtle cannot survive in the wild by herself for too long.";
				puzzlePiece.enabled = !puzzlePiece.enabled;
				counter++;
			} else if (counter == 5) {
				storyText.text = "Press return to help Jami find her family in time.";
				counter++;
			}
		}
		if (Input.GetKeyDown (KeyCode.Return)) {
			SceneManager.LoadScene ("Level 1");
		}
		if (Input.GetKeyDown(KeyCode.Escape)) {
			//Application.Quit();
			SceneManager.LoadScene ("StartingMenu");
		}
	
	}
}
