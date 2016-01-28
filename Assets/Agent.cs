using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour 
{
	public Vector3 position;
	public float heading = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void AgentUpdate () 
	{
		heading = Mathf.RoundToInt(gameObject.transform.rotation.eulerAngles.y);
		position = gameObject.transform.position;
	}
}
