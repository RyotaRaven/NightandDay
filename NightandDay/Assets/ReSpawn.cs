using UnityEngine;
using System.Collections;

public class ReSpawn : MonoBehaviour {

	float spawnx;
	float spawny;

	void OnTriggerEnter2D(Collider2D col)
	{
		//TODO: set respawn location based on the current level/checkpoint
		if(col.collider2D.tag=="Player") col.transform.position=new Vector2(spawnx, spawny);
	}
	public static void setSpawnPoint(float x, float y)
	{
		spawnx = x;
		spawny = y;
	}
}
