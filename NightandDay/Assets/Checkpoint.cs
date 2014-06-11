using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {



	void OnTriggerEnter2D(Collider2D col)
	{

		if(col.collider2D.tag=="Player") {
			Player p = col.gameObject.GetComponent<Player>();
			p.setSpawnPoint(this.transform.position.x, this.transform.position.y);
		}
	}

}
