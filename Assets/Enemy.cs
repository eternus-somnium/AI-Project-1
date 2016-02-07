using UnityEngine;
using System.Collections;

public class Enemy : Agent 
{
	public int range;
	Vector3 startPosition;
	// Use this for initialization
	void Start () 
	{
		startPosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		AgentUpdate();
	}
}
