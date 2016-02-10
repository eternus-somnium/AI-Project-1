using UnityEngine;
using System.Collections;

public class WallSensors : MonoBehaviour 
{
	public float[] wallSensorReadings = new float[3]; //0=forward, 1=right, 2=left
	public int wallSensorRange;
	public bool showWallSensors;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Sensors();
		if(showWallSensors) VisualizeWallSensors();
	}

	void Sensors()
	{
		//Create rays
		Ray fWallSensor = new Ray(gameObject.transform.position, gameObject.transform.forward);
		Ray rWallSensor = new Ray(gameObject.transform.position, gameObject.transform.right);
		Ray lWallSensor = new Ray(gameObject.transform.position, -gameObject.transform.right);
		
		RaycastHit h;
		
		//Set raycast results
		//Forward
		if(Physics.Raycast(fWallSensor, out h, wallSensorRange) && h.transform.gameObject.tag == "Wall")
			wallSensorReadings[0] = Vector3.Distance(gameObject.transform.position, h.point);
		else wallSensorReadings[0] = -1;

		//Right
		if(Physics.Raycast(rWallSensor, out h, wallSensorRange) && h.transform.gameObject.tag == "Wall")
			wallSensorReadings[1] = Vector3.Distance(gameObject.transform.position, h.point);
		else wallSensorReadings[1] = -1;

		//Left
		if(Physics.Raycast(lWallSensor, out h, wallSensorRange) && h.transform.gameObject.tag == "Wall")
			wallSensorReadings[2] = Vector3.Distance(gameObject.transform.position, h.point);
		else wallSensorReadings[2] = -1;
	}


	void VisualizeWallSensors()
	{
		Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward*wallSensorRange, Color.black);
		Debug.DrawRay(gameObject.transform.position, gameObject.transform.right*wallSensorRange, Color.black);
		Debug.DrawRay(gameObject.transform.position, -gameObject.transform.right*wallSensorRange, Color.black);
	}
}
