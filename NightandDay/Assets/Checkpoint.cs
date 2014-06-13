using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	public bool isFinalCheckpoint = false;


	void OnTriggerEnter2D(Collider2D col)
	{

		if(col.collider2D.tag=="Player" && isFinalCheckpoint) {
			LoadLevel.loadNextLevel();
		} else {
			Player p = col.gameObject.GetComponent<Player>();
			p.setSpawnPoint(this.transform.position.x, this.transform.position.y);
		}
	}

}
