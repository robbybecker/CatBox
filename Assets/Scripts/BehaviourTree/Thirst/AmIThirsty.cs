using UnityEngine;
using System.Collections;
using BehaviourTreeSpace;

[System.Serializable]
public class AmIThirsty : BehaviourNode 
{
	public override NodeStatus Tick (TreeEntity entity)
	{
		Thirst thirst = entity.GetComponent<Thirst>();
		if(thirst.thirstState == ThirstState.Thirsty || thirst.thirstState == ThirstState.Dehydrated || thirst.thirstState == ThirstState.Parched)
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