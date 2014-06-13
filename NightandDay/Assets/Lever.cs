﻿using UnityEngine;
using System.Collections;

public class Lever : ToggleActivator {

	public GameObject lever;
	public Sprite[] leverSprites;  // Initialized in the editor
	int whichLever = 0;

	void OnTriggerStay2D (Collider2D col)
	{
		if (col.collider2D.tag == "Player")
		{
			if (Input.GetButtonDown("Fire2"))
			{
				if(whichLever == 0) {
					activated = true;
					whichLever = 1;
				} else {
					whichLever = 0; 
					activated = false;
				}
				lever.GetComponent<SpriteRenderer>().sprite = leverSprites[whichLever];
				wall.GetComponent<WallUnlock>().updateWallOpenStatus();
			}
		}
	}
}
