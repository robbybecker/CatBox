using UnityEngine;
using System.Collections;
using BehaviourTreeSpace;

public class IsCatLitterDirty : BehaviourNode
{	
	public override NodeStatus Tick (TreeEntity entity)
	{
		if(entity.dataContextGameObject.ContainsKey("CatLitter") == false)
		{
			nodeStatus = NodeStatus.Failure;			
			return nodeStatus;
		}
		CatLitter catLitter = entity.dataContextGameObject["CatLitter"].GetComponent<CatLitter>();
		if(catLitter.quantity == 0)
		{
			nodeStatus = NodeStatus.Success;
		}
		else
		{
			nodeStatus = NodeStatus.Failure;			
		}
		return nodeStatus;
	}
}