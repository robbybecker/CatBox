using UnityEngine;
using System.Collections;
using BehaviourTreeSpace;

public class UseObject : BehaviourNode
{
	public string objectToUse;
	
	public override NodeStatus OnTick (TreeEntity entity)
	{
		if(objectToUse.Length == null)
		{
			return NodeStatus.Failure;
		}
		if(entity.dataContextGameObject.ContainsKey(objectToUse) == false)
		{
			return NodeStatus.Failure;
		}
		IUseable iUseable = entity.dataContextGameObject[objectToUse].GetComponent<IUseable>();
		if(iUseable == null)
		{		
			return NodeStatus.Failure;			
		}
		if(iUseable.IsObjectUsable() == false)
		{
			return NodeStatus.Failure;			
		}
		if(iUseable.UseObject(entity)) // if true we are are good with that need
		{
			return NodeStatus.Success;
		}
		return NodeStatus.Running;
	}
}