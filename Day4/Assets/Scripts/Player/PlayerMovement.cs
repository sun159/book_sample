using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]  
public class PlayerMovement: MonoBehaviour {
	
	protected Animator avatar;
	protected PlayerAttack playerAttack;

	void Start () 
	{
		avatar = GetComponent<Animator>();
		playerAttack = GetComponent<PlayerAttack>();
	}
    
	float h, v;

	public void OnStickChanged(Vector2 stickPos)
	{
		h = stickPos.x;
		v = stickPos.y;
	}

	void Update () 
	{

		if(avatar)
		{
			avatar.SetFloat("Speed", (h*h+v*v));

		    Rigidbody rigidbody = GetComponent<Rigidbody>();

            if(rigidbody)
            {
                Vector3 speed = rigidbody.velocity;
                speed.x = 4 * h;
                speed.z = 4 * v;
                rigidbody.velocity = speed;
				if(h != 0f && v != 0f){
					transform.rotation = Quaternion.LookRotation(new Vector3(h, 0f, v));
				}

            }

		}		
	}



}
