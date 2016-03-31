using UnityEngine;
using System.Collections;
using BehaviourTreeSpace;

[System.Serializable]
public class MoveToLocation : BehaviourNode 
{		
	public override NodeStatus OnTick (TreeEntity entity)
	{
		if(entity.dataContextVector.ContainsKey("moveToLocation") == false)
		{
			return NodeStatus.Failure;			
		}
		Vector3 walkLocation = entity.dataContextVector["moveToLocation"];
		Movement movement = entity.GetComponent<Movement>();
		movement.Move(walkLocation);
		if(Vector3.Distance(entity.transform.position, walkLocation) <= movement.stoppingDistance)
		{
			entity.dataContextVector.Remove("moveToLocation");
			return NodeStatus.Success;
		}
		else
		{
			return NodeStatus.Running;
		}
	}
}