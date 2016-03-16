using UnityEngine;
using System.Collections;
using BehaviourTreeSpace;

[System.Serializable]
public class MoveToLocation : BehaviourNode 
{
	private Movement movement;
	private Vector3 walkLocation;
	
	public override void OnEnterNode (TreeEntity entity)
	{
		object outObject;
		movement = entity.GetComponent<Movement>();
		if(entity.dataContext.TryGetValue("moveToLocation", out outObject))
		{
			walkLocation = (Vector3)outObject;
		}
		else
		{
			nodeStatus = NodeStatus.Failure;			
		}
	}
	
	public override NodeStatus Tick (TreeEntity entity)
	{
		movement.Move(walkLocation);
		if(Vector3.Distance(entity.transform.position, walkLocation) <= movement.stoppingDistance)
		{
			nodeStatus = NodeStatus.Success;
			entity.dataContext.Remove("moveToLocation");
		}
		else
		{
			nodeStatus = NodeStatus.Running;
		}
		return nodeStatus;
	}
}