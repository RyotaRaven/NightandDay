using UnityEngine;
using System.Collections;

public class WallUnlock : MonoBehaviour {

	
	public GameObject[] triggers;
	public MeshRenderer[] obstacle;
	private int toOpen;
	private bool[] canOpen;
	public GameObject[] wall;
	private bool open;
	
	// Use this for initialization
	void Start () { 
		canOpen = new bool[triggers.Length];
		updateWallOpenStatus();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void updateWallOpenStatus() {
		for (int i=0; i<canOpen.Length; i++)
			canOpen [i] = triggers [i].GetComponent<Lever> ().activated;
		
		// Sets the open bool
		open=canOpen[0];
		for(int x=0; x<canOpen.Length; x++)
		{
			open &= canOpen[x];
		}
		
		
		if (open)
		{
			foreach(MeshRenderer m in obstacle)
			{
				m.enabled=false;
			}
			foreach(GameObject o in wall)
			{
				o.collider2D.isTrigger=true;
			}
		}
		else
		{
			foreach(MeshRenderer m in obstacle)
			{
				if(m.enabled==false) m.enabled=true;
			}
			foreach(GameObject o in wall)
			{
				if(o.collider2D.isTrigger==true) o.collider2D.isTrigger=false;
			}
		}

	}
}

