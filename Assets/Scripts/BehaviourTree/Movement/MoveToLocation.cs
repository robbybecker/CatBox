using UnityEngine;
using System.Collections;
using BehaviourTreeSpace;

[System.Serializable]
public class MoveToLocation : BehaviourNode 
{	
	public override void OnEnterNode (TreeEntity entity)
	{
		if(entity.dataContextVector.ContainsKey("moveToLocation") == false)
		{
			nodeStatus = NodeStatus.Failure;			
		}
	}
	
	public override NodeStatus Tick (TreeEntity entity)
	{
		Vector3 walkLocation = entity.dataContextVector["moveToLocation"];
		Movement movement = entity.GetComponent<Movement>();
		movement.Move(walkLocation);
		if(Vector3.Distance(entity.transform.position, walkLocation) <= movement.stoppingDistance)
		{
			nodeStatus = NodeStatus.Success;
			entity.dataContextVector.Remove("moveToLocation");
		}
		else
		{
			nodeStatus = NodeStatus.Running;
		}
		return nodeStatus;
	}
}