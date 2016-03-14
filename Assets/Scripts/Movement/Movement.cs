using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
	private NavMeshAgent _navMeshAgent;	
	public float stoppingDistance = 1f;

	void Start () 
	{
		_navMeshAgent = GetComponent<NavMeshAgent>();
	}

	public void Move(Vector3 targetPos) 
	{
		_navMeshAgent.SetDestination(targetPos);
	}

	public void Move(Transform target) 
	{
		Move (target.position);
	}
}