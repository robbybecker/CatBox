using UnityEngine;
using System.Collections;
using BehaviourTreeSpace;

public class IsCatLitterDirty : BehaviourNode
{	
//	public override void OnEnterNode (TreeEntity entity)
	public override NodeStatus Tick (TreeEntity entity)
	{
		object outObject;
		if(entity.dataContext.TryGetValue("CatLitter", out outObject) == false)
		{
			nodeStatus = NodeStatus.Failure;			
			return nodeStatus;
		}
		if(outObject == null)
		{
			nodeStatus = NodeStatus.Failure;
			return nodeStatus;
		}
		CatLitter catLitter = ((GameObject)outObject).GetComponent<CatLitter>();
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