using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AdjacencySensor : MonoBehaviour 
{
	public List<GameObject> sensedAgents = new List<GameObject>();
	public List<float> sensedAgentHeadings;
	public int adjacencySensorRange;
	public bool showAdjacencySensor;

	// Use this for initialization
	void Start () 
	{
		Invoke("RemoveSelf",1);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Sensor();
		AgentHeadings();
	}

	void Sensor()
	{
		Vector3 aSensorRange = new Vector3(adjacencySensorRange*2,.1f,adjacencySensorRange*2);
		
		if(gameObject.transform.localScale != aSensorRange)
			gameObject.transform.localScale = aSensorRange;
		
		if(gameObject.GetComponent<MeshRenderer>().enabled != showAdjacencySensor)
			gameObject.GetComponent<MeshRenderer>().enabled = showAdjacencySensor;
	}

	void AgentHeadings()
	{
		sensedAgentHeadings = new List<float>();
		foreach(GameObject g in sensedAgents)
			sensedAgentHeadings.Add(g.GetComponent<Agent>().heading);
	}

	//Takes the sensing game object out of its own sensed agents list
	void RemoveSelf()
	{
		sensedAgents.Remove(gameObject.transform.parent.gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		sensedAgents.Add (other.gameObject);
	}

	void OnTriggerExit(Collider other)
	{
		sensedAgents.Remove (other.gameObject);
	}
}
