using UnityEngine;
using System.Collections;

public class TestMove : MonoBehaviour 
{
	private NavMeshAgent _navMeshAgent;

	public Transform target;

	// Use this for initialization
	void Start () 
	{
		_navMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		_navMeshAgent.SetDestination(target.position);
	}
}
