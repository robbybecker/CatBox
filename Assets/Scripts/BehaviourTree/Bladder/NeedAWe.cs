using UnityEngine;
using System.Collections;
using BehaviourTreeSpace;

public class NeedAWe : BehaviourNode 
{
	public override NodeStatus OnTick (TreeEntity entity)
	{
		Bladder bladder = entity.GetComponent<Bladder>();
		if(bladder.DoWeNeedTheNeed())
		{
			return NodeStatus.Success;
		}
		else
		{
			return NodeStatus.Failure;
		}	
	}
}