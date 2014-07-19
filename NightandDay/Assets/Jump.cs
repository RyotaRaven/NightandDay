using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public static bool onGround;

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.collider2D.tag=="Ground") onGround = true;

	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		if(col.collider2D.tag=="Ground") onGround = false;
	}
}
