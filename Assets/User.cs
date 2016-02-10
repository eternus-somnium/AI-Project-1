using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class User : Agent 
{
	CharacterController controller;

	// Use this for initialization
	void Start () 
	{
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		AgentUpdate();
		MoveController();
	}

	void MoveController()
	{	
		transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal")*2, 0));

		Vector3 moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);// makes input directions heading relative
		moveDirection *= 10;

		controller.Move(moveDirection * Time.deltaTime);
	}


}
