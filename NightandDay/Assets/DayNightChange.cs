using UnityEngine;
using System.Collections;

public class DayNightChange : MonoBehaviour {

	bool isNight=false;
	Color night;
	Color day;


	// Use this for initialization
	void Start () {
		night= new Color32(30, 56, 98,255);
		day= new Color32(163,199,255,255);
		camera.clearFlags = CameraClearFlags.SolidColor;
		//ignoring collisions for night
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Night"),0, true);			
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Day"), 0, false);
	
	}
	//8 is day layer, 9 is night layer
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Fire1"))
		{
			if(isNight)
			{
				isNight=false;
				camera.backgroundColor = day;
				camera.cullingMask = (1<< LayerMask.NameToLayer("Day")) | (1<<0);
				Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Night"),0, true);			
				Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Day"), 0, false);
			}
			else
			{
				isNight=true;
				camera.backgroundColor = night;
				camera.cullingMask = (1<< LayerMask.NameToLayer("Night"))| (1<<0);
				Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Night"),0, false);			
				Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Day"),0, true);
			}
		}
	}

	

	
}
