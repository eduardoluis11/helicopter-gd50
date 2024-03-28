using UnityEngine;
using System.Collections;

public class GemSpawner : MonoBehaviour {

	public GameObject[] prefabs;

	// Use this for initialization
	void Start () {

		// infinite gem spawning function, asynchronous
		StartCoroutine(SpawnGems());
	}

	// Update is called once per frame
	void Update () {

	}

    /* This spawns the Gems at random intervals.

    In the original SpawnCoins() function the Random.Range(1, 4) function would spawn between 1 and 3 coins, one above
    the other. That is, normally, 1 coin shows up. However, sometimes, 3 coins show up one above the other. This is
    so that you could grabe multiple coins at once. However, this is not the case for the gems.If gems are special since
    they give you a lot of points, what's the point of being able to spawn 3 of them at once,
    one above the other? It would be too easy to get a lot of points. So, I changed the Random.Range(1, 4) function to
    Random.Range(1, 2) so that only 1 gem shows up at a time. This way, the player has to work harder to get more
    points.

    However, since the assignment says "Add Gems to the game that spawn in much the same way as Coins", I'm going to
    still spawn between 1 and 3 gems at a time, so that gems behave similarly to coins.

    Nevertheless, I still need to edit this function, since I need to decrease the spawn rate of the gems, so that they
    spawn at a slower rate than the coins.

    The "Random.Range(-10, 10)" snippet decides the y position of the gems. Even if 3 gems spawn one above the other,
    they will be at different heights. I will leave this as is, since it is not a problem.

    The WaitForSeconds() function decides how long it takes for the next gem to spawn. However, I don't want the
    gems to spawn at fixed intervals. I want them to spawn at random intervals. That's what the Randon.Range() function
    is for: it takes a random number, and then waits that many seconds before spawning the next gem. This way,
    it sometimes takes 10 seconds to render the next gems, but sometimes it takes 15 seconds to spawn the next gem.
    That is, the gems are being spawned at random intervals. The 2 numbers within the Random.Range() function are the
    minimum and maximum number of seconds it takes for the next gem to spawn (source: Copilot.) I chose between 10 and
    30 seconds since Copilot recommended it (source: Copilot.)
    */
	IEnumerator SpawnGems() {
		while (true) {

			// number of gems we could spawn vertically (between 1 and 3)
			int gemsThisRow = Random.Range(1, 4);

			// instantiate all gems in this row separated by some random amount of space
			for (int i = 0; i < gemsThisRow; i++) {
				Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(26, Random.Range(-10, 10), 10), Quaternion.identity);
			}

			// This generates the Gems at random intervals. The intervals are way longer than for the coins.
			yield return new WaitForSeconds(Random.Range(10, 30));
		}
	}
}
