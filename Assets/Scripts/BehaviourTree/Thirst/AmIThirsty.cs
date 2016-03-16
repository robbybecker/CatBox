﻿using UnityEngine;
using System.Collections;
using BehaviourTreeSpace;

[System.Serializable]
public class AmIThirsty : BehaviourNode 
{
	public override NodeStatus Tick (TreeEntity entity)
	{
		Thirst thirst = entity.GetComponent<Thirst>();
		if(thirst.DoWeNeedTheNeed())
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