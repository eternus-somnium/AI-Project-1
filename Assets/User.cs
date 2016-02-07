using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class User : Agent 
{
	CharacterController controller;

	public float[] wallSensorReadings = new float[3]; //0=forward, 1=right, 2=left
	public int wallSensorRange;
	public bool showWallSensors;

	public List<GameObject> sensedAgents = new List<GameObject>();
	public int adjacencySensorRange;
	public bool showAdjacencySensor;
	public GameObject adjacencySensor;


	// Use this for initialization
	void Start () 
	{
		controller = GetComponent<CharacterController>();
		Invoke("RemoveSelf",1);
	}
	
	// Update is called once per frame
	void Update () 
	{
		AgentUpdate();
		MoveController();

		WallSensors();
		if(showWallSensors) VisualizeWallSensors();

		AdjacencySensor();
	}

	void WallSensors()
	{
		//Create rays
		Ray fWallSensor = new Ray(gameObject.transform.position, gameObject.transform.forward);
		Ray rWallSensor = new Ray(gameObject.transform.position, gameObject.transform.right);
		Ray lWallSensor = new Ray(gameObject.transform.position, -gameObject.transform.right);

		RaycastHit h;


		if(Physics.Raycast(fWallSensor, out h, wallSensorRange))
			wallSensorReadings[0] = Vector3.Distance(gameObject.transform.position, h.point);
		else wallSensorReadings[0] = -1;

		//Debug.Log("F " +h.point);

		if(Physics.Raycast(rWallSensor, out h, wallSensorRange))
			wallSensorReadings[1] = Vector3.Distance(gameObject.transform.position, h.point);
		else wallSensorReadings[1] = -1;

		//Debug.Log("R " + h.point);


		if(Physics.Raycast(lWallSensor, out h, wallSensorRange))
			wallSensorReadings[2] = Vector3.Distance(gameObject.transform.position, h.point);
		else wallSensorReadings[2] = -1;

		//Debug.Log("L" + h.point);

	}

	void VisualizeWallSensors()
	{
		Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward*wallSensorRange, Color.black);
		Debug.DrawRay(gameObject.transform.position, gameObject.transform.right*wallSensorRange, Color.black);
		Debug.DrawRay(gameObject.transform.position, -gameObject.transform.right*wallSensorRange, Color.black);
	}

	void AdjacencySensor()
	{
		Vector3 aSensorRange =new Vector3(adjacencySensorRange,.1f,adjacencySensorRange);

		if(adjacencySensor.transform.localScale != aSensorRange)
			adjacencySensor.transform.localScale = aSensorRange;

		if(adjacencySensor.GetComponent<MeshRenderer>().enabled != showAdjacencySensor)
			adjacencySensor.GetComponent<MeshRenderer>().enabled = showAdjacencySensor;
	}


	void MoveController()
	{	
		transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal")*2, 0));

		Vector3 moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);// makes input directions heading relative
		moveDirection *= 10;

		controller.Move(moveDirection * Time.deltaTime);
	}

	//Takes the sensing game object out of the sensed agents list
	void RemoveSelf()
	{
		sensedAgents.Remove(gameObject);
	}
}
