using UnityEngine;
using System.Collections;
using BehaviourTreeSpace;

[System.Serializable]
public class AmIThirsty : BehaviourNode 
{
	public override NodeStatus OnTick (TreeEntity entity)
	{
		Thirst thirst = entity.GetComponent<Thirst>();
		if(thirst.DoWeNeedTheNeed())
		{
			return NodeStatus.Success;
		}
		else
		{
			return NodeStatus.Failure;
		}	
	}
}