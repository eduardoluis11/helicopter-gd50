using UnityEngine;
using System.Collections;

public class SkyscraperSpawner : MonoBehaviour {

	public GameObject[] prefabs;
	public static float speed = 10f;

	// Use this for initialization
	void Start () {

		// aysnchronous infinite skyscraper spawning
		StartCoroutine(SpawnSkyscrapers());
	}

	// Update is called once per frame
	void Update () {

	}

    /* This spawns skyscrapers at random intervals and increases the speed of the game
     * as the player progresses.

     Although this function is what makes the game run faster and faster as the game goes on (for the skyscrapers,
     coins, and planes,) this is NOT the function nor the file with the bug that makes the game keep the same high speed
     when you hit the Space bar after you get a Game Over. However, this should give me a hint as to the file
     where the bug is located.
    */
	IEnumerator SpawnSkyscrapers() {
		while (true) {

			// create a new skyscraper from prefab selection at right edge of screen
			Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(26, Random.Range(-20, -12), 11),
				Quaternion.Euler(-90f, 0f, 0f));

			// randomly increase the speed by 1
			if (Random.Range(1, 4) == 1) {
				speed += 1f;
			}

			// wait between 1-5 seconds for a new skyscraper to spawn
			yield return new WaitForSeconds(Random.Range(1, 5));
		}
	}
}
