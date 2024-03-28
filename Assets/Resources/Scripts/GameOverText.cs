using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameOverText : MonoBehaviour {

	public GameObject helicopter;
	private Text text;
	private int coins;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();

		// start text off as completely transparent black
		text.color = new Color(0, 0, 0, 0);
	}

	// Update is called once per frame
	void Update () {
		if (helicopter != null) {
			coins = helicopter.GetComponent<HeliController>().coinTotal;
		}
		else {

			// reveal text only when helicopter is null (destroyed)
			text.color = new Color(0, 0, 0, 1);
			text.text = "Game Over\nYour Score:\n" + coins + " Coins\nPress Space to Restart!";

			/* I think this is what resets the game after you hit the Space Bar during the "Game Over" screen.

			I men, this resets the music, the scene, the score, etc. However, this isn't resetting the speed back to a
			slow speed once you hit the space bar. So, I think I need to edit this to fix the bug in which the
			game is still at the same quick speed as it was right after you died.

            To try to fix the speed bug, I will access the "speed" variable from SkyscraperSpawner.cs in here, and reset
            it back to its original slow speed, which is of "10f." Apparently, since "speed" is a static value, it's
            the equivalent of a global variable, so I can access it from here. (source: Copilot)

            IT IS! This fixed the speed bug!
			*/
			// jump is space bar by default
			if (Input.GetButtonDown("Jump")) {

			    // This resets the speed back to its original slow speed, fixing the speed bug (source: Copilot)
                SkyscraperSpawner.speed = 10f;

				// reload entire scene, starting music over again, refreshing score, etc.
				SceneManager.LoadScene("Main");
			}
		}
	}
}
