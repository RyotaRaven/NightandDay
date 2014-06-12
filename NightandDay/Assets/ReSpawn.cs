using UnityEngine;
using System.Collections;

public class ReSpawn : MonoBehaviour {

	float spawnx;
	float spawny;

	void Start() {
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		// Set respawn location based on the player's current level/checkpoint
		if(col.collider2D.tag=="Player") {
			Player p = col.gameObject.GetComponent<Player>();
			p.transform.position = new Vector2(p.respawnX, p.respawnY+2);
		}
	}

}
