using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour	{

	public static void loadNextLevel() {
		// Load the next level in sequence
		int nextLevel = Application.loadedLevel + 1;
		if (nextLevel < NDConstants.NUM_LEVELS) {
			Debug.Log ("Loading level " + nextLevel);
			Application.LoadLevel(nextLevel);
		}
	}


}