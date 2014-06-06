using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{

	public int speed;
	public int jumpHeight;
	float x,y;
	bool onGround;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		onGround = Jump.onGround;
		//move left and right
		Vector3 pos = transform.position;
		pos.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		transform.position = pos;
		//jump
		if(Input.GetButtonDown("Jump") )
		{
			rigidbody2D.AddForce(new Vector2(0,jumpHeight));
		}
	}

}
