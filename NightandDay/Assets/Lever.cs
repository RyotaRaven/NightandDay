using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour {

	public GameObject lever;
	public Sprite[] newLever;
	int whichLever=0;

	public bool activated=false;

	void OnTriggerStay2D (Collider2D col)
	{
		if (col.collider2D.tag == "Player")
		{
			if(Input.GetButtonDown("Fire2"))
			{
				if(whichLever==0) {activated=true; whichLever=1;} 
				else {whichLever=0; activated=false;}
				lever.GetComponent<SpriteRenderer>().sprite=newLever[whichLever];
			}
		}
	}
}
