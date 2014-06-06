using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public static bool onGround;

	void onTriggerEnter2D(Collision2D col)
	{
		Debug.Log ("COLLISION");
		if(col.collider.tag=="ground") onGround = true;
	}
	
	void onTriggerExit2D(Collision2D col)
	{
		if(col.collider.tag=="ground") onGround = false;
	}
}
