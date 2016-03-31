using UnityEngine;
using System.Collections;
using BehaviourTreeSpace;

[System.Serializable]
public class AmIHungry : BehaviourNode 
{
	public override NodeStatus OnTick (TreeEntity entity)
	{
		Hunger hunger = entity.GetComponent<Hunger>();
		if(hunger.DoWeNeedTheNeed())
		{
			return NodeStatus.Success;
		}
		else
		{
			return NodeStatus.Failure;
		}	
	}
}