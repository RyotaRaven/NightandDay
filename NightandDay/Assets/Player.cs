﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	public int speed;
	public int jumpHeight;
	public Sprite[] dayNightSprites;
	// Respawn location
	public float respawnX, respawnY;
	public WeightedEntity carriedEntity;
	int playerSkin = 0;
	// Current position
	float x,y;
	bool onGround;
	bool facingRight=true;
	bool isMoving=false;
	bool holdingSomething=false;

	// Use this for initialization
	void Start () 
	{
		respawnX = -5.3f;
		respawnY = 0.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		onGround = Jump.onGround;
		//move left and right
		Vector3 pos = transform.position;
		if(Input.GetAxis ("Horizontal")!=0 && !isMoving)
	    {
			if(Input.GetAxis ("Horizontal")>0 && !facingRight)
			{
				Flip ();
			}
			if(Input.GetAxis ("Horizontal")<0 && facingRight)
			{
				Flip ();
			}
			isMoving=true;
		}
		//for animation and turning
		else if(Input.GetAxis ("Horizontal")==0)
			isMoving=false;
		pos.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		transform.position = pos;
		//jump
		if(Input.GetButtonDown("Jump") && onGround)
		{
			rigidbody2D.AddForce(new Vector2(0,jumpHeight));
		}
		//changing the character based on day and night
		if(Input.GetButtonDown ("Fire1"))
		{
			if(playerSkin==0) playerSkin=1;
			else playerSkin=0;
			gameObject.GetComponent<SpriteRenderer>().sprite= dayNightSprites[playerSkin];
		}
		//dropping objects
		if(Input.GetButtonDown ("Fire3") && holdingSomething)
		{
			Debug.Log ("Drop");
			GameObject ch= GameObject.Find ("Cube");
			ch.transform.parent=null;
			holdingSomething=false;
			if(ch.GetComponent<Rigidbody2D>()!=null)
			{
				ch.GetComponent<Rigidbody2D>().isKinematic=false;
			}
		}
	}
		
	public void setSpawnPoint(float x, float y)
	{
		respawnX = x;
		respawnY = y;
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if(col.collider2D.tag=="WeightedObject")
		{
			if(Input.GetButtonDown("Fire3"))
			{
				holdingSomething=true;
				Debug.Log ("PickUp");
				col.gameObject.layer= 0<<LayerMask.NameToLayer("Default");
				col.transform.parent= transform;
				Vector2 temp=col.transform.position;
				temp.y+=.5f;
				col.transform.position=temp;
				if(col.GetComponent<Rigidbody2D>()!=null)
				{
					col.GetComponent<Rigidbody2D>().isKinematic=true;
				}
			}
		}
	}
}


