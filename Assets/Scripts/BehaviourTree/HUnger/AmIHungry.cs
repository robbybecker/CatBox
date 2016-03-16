using UnityEngine;
using System.Collections;
using BehaviourTreeSpace;

[System.Serializable]
public class AmIHungry : BehaviourNode 
{
	public override NodeStatus Tick (TreeEntity entity)
	{
		Hunger hunger = entity.GetComponent<Hunger>();
		if(hunger.DoWeNeedTheNeed())
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