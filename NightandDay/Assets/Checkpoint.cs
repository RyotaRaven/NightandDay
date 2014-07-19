using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	public bool isFinalCheckpoint;


	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log ("HEY ITS A THING!!");

		if(col.collider2D.tag=="Player" && isFinalCheckpoint) 
		{
			Application.LoadLevel(Application.loadedLevel+1);
			Debug.Log ("Level completed.");
		} 
		else if(col.collider2D.tag=="Player")
		{
			Debug.Log("Repawn point set.");
			Player p = col.gameObject.GetComponent<Player>();
			p.setSpawnPoint(transform.position.x, transform.position.y);
		}
	}

}
