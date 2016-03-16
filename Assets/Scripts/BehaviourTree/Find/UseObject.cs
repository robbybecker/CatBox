using UnityEngine;
using System.Collections;
using BehaviourTreeSpace;

public class UseObject : BehaviourNode
{
	private IUseable iUseable;
	public string objectToUse;
	
	public override void OnEnterNode (TreeEntity entity)
	{
		if(objectToUse.Length == null)
		{
			nodeStatus = NodeStatus.Failure;
			return;
		}
		object outObject;
		if(entity.dataContext.TryGetValue(objectToUse, out outObject) == false)
		{
			nodeStatus = NodeStatus.Failure;
			return;
		}
		if(outObject == null)
		{
			nodeStatus = NodeStatus.Failure;			
			return;
		}
		iUseable = ((GameObject)outObject).GetComponent<IUseable>();
		if(iUseable == null)
		{		
			nodeStatus = NodeStatus.Failure;			
			return;
		}
	}
	
	public override NodeStatus Tick (TreeEntity entity)
	{
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
