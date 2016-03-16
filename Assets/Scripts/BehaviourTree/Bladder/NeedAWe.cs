using UnityEngine;
using System.Collections;
using BehaviourTreeSpace;

public class NeedAWe : BehaviourNode 
{
	public override NodeStatus Tick (TreeEntity entity)
	{
		Bladder bladder = entity.GetComponent<Bladder>();
		if(bladder.DoWeNeedTheNeed())
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