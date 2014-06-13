using UnityEngine;
using System.Collections;

public class PressurePlate : ToggleActivator {

	void OnTriggerStay2D (Collider2D col)
	{
		if (col.collider2D.tag == "Player" || col.collider2D.tag== "WeightedObject")
		{
			activated = true;
			wall.GetComponent<WallUnlock>().updateWallOpenStatus();

		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.collider2D.tag == "Player" || col.collider2D.tag== "WeightedObject")
		{
			activated = false;
			wall.GetComponent<WallUnlock>().updateWallOpenStatus();
			
		}

	}
}
