using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{

	public int speed;
	public int jumpHeight;
	public Material[] dayNight;
	int player= 0;
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
		if(Input.GetButtonDown("Jump") && onGround)
		{
			rigidbody2D.AddForce(new Vector2(0,jumpHeight));
		}
		if(Input.GetButtonDown ("Fire1"))
		{
			if(player==0) player=1;
			else player=0;
			renderer.material= dayNight[player];
		}
	}

}
