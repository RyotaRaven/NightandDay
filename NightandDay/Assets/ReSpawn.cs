using UnityEngine;
using System.Collections;

public class ReSpawn : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		float spawnx = -5.3f;
		float spawny = -1.0f;
		if(col.collider2D.tag=="Player") col.transform.position=new Vector2(spawnx, spawny);
	}
}
