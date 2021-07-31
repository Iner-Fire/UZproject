using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	//variables
	public float moveSpeed = 1f;
	public Vector2 movement;
	public Rigidbody2D rigibody;
	public Animator anim;
	public float hf = 0.0f;
	public float speed = 0.0f;

	// Use this for initialization
	void Start()
	{
		rigibody = this.GetComponent<Rigidbody2D>();
		anim = this.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
		movement = movement.normalized;
		hf = movement.x > 0.01f ? movement.x : movement.x < -0.01f ? 1 : 0;
		speed = movement.y > 0.01f ? movement.y : movement.y < -0.01f ? 1 : 0;
		if (movement.x < -0.01f)
		{
			this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
		}
		else
		{
			this.gameObject.transform.localScale = new Vector3(1, 1, 1);
		}

		anim.SetFloat("Horizontal", hf);
		anim.SetFloat("Vertical", movement.y);
		anim.SetFloat("Speed", speed);
	}
	void FixedUpdate()
	{
		rigibody.MovePosition(rigibody.position + movement * moveSpeed * Time.fixedDeltaTime);
	}
}

