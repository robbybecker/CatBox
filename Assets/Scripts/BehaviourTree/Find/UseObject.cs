using UnityEngine;
using System.Collections;
using BehaviourTreeSpace;

public class UseObject : BehaviourNode
{
	public string objectToUse;
	
	public override void OnEnterNode (TreeEntity entity)
	{
		if(objectToUse.Length == null)
		{
			nodeStatus = NodeStatus.Failure;
			return;
		}
		if(entity.dataContextGameObject.ContainsKey(objectToUse) == false)
		{
			nodeStatus = NodeStatus.Failure;
			return;
		}
	}
	
	public override NodeStatus Tick (TreeEntity entity)
	{
		IUseable iUseable = entity.dataContextGameObject[objectToUse].GetComponent<IUseable>();
		if(iUseable == null)
		{		
			nodeStatus = NodeStatus.Failure;			
			return nodeStatus;
		}
		if(iUseable.IsObjectUsable() == false)
		{
			nodeStatus = NodeStatus.Failure;			
			return nodeStatus;
		}
		nodeStatus = NodeStatus.Running;			
		if(iUseable.UseObject(entity)) // if true we are are good with that need
		{
			nodeStatus = NodeStatus.Success;
		}
		return nodeStatus;
	}
}