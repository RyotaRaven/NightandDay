using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	public int speed;
	public int jumpHeight;
	public Sprite[] dayNightSprites;
	public float respawnX, respawnY;
	public WeightedEntity carriedEntity;
	int playerSkin = 0;
	// Current position
	float x,y;
	bool onGround;
	bool facingRight=true;
	bool isMoving=false;
	//bool holdingSomething=false;
	// Respawn location

	// Use this for initialization
	void Start () 
	{
		respawnX = -5.3f;
		respawnY = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
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
		else if(Input.GetAxis ("Horizontal")==0)
			isMoving=false;
		pos.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		transform.position = pos;
		//jump
		if(Input.GetButtonDown("Jump") && onGround)
		{
			rigidbody2D.AddForce(new Vector2(0,jumpHeight));
		}
		if(Input.GetButtonDown ("Fire1"))
		{
			if(playerSkin==0) playerSkin=1;
			else playerSkin=0;
			gameObject.GetComponent<SpriteRenderer>().sprite= dayNightSprites[playerSkin];
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



}
