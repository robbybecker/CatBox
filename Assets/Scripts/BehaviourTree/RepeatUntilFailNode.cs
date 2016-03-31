using UnityEngine;
using System.Collections;
using System;

namespace BehaviourTreeSpace
{
	[Serializable]
	/// <summary>
	/// Repeat until fail node - repeats until it fails
	/// </summary>
	public class RepeatUntilFailNode : DecoratorNode 
	{
		public override NodeStatus OnTick (TreeEntity entity)
		{
			NodeStatus nodeStatus = NodeStatus.Running;
			do
			{
				nodeStatus = OnTick(entity);
				if(nodeStatus != NodeStatus.Success && nodeStatus != NodeStatus.Failure)
					return nodeStatus;
			}
			while(nodeStatus != NodeStatus.Failure);
			return NodeStatus.Success;;
		}
	}
}