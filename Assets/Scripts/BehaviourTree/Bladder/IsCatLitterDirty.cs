using UnityEngine;
using System.Collections;
using BehaviourTreeSpace;

public class IsCatLitterDirty : BehaviourNode
{	
	public override NodeStatus OnTick (TreeEntity entity)
	{
		if(entity.dataContextGameObject.ContainsKey("CatLitter") == false)
		{		
			return NodeStatus.Failure;
		}
		CatLitter catLitter = entity.dataContextGameObject["CatLitter"].GetComponent<CatLitter>();
		if(catLitter.quantity == 0)
		{
			return NodeStatus.Success;
		}
		else
		{
			return NodeStatus.Failure;			
		}
	}
}