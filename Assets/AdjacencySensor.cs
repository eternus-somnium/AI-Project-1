using UnityEngine;
using System.Collections;

public class AdjacencySensor : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		gameObject.transform.parent.GetComponent<User>().sensedAgents.Add (other.gameObject);
	}

	void OnTriggerExit(Collider other)
	{
		gameObject.transform.parent.GetComponent<User>().sensedAgents.Remove (other.gameObject);
	}
}
