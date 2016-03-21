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
		public override NodeStatus Tick (TreeEntity entity)
		{
			do
			{
				nodeStatus = Tick(entity);
				if(nodeStatus != NodeStatus.Success && nodeStatus != NodeStatus.Failure)
					return nodeStatus;
			}
			while(nodeStatus != NodeStatus.Failure);

			nodeStatus = NodeStatus.Success;
			return nodeStatus;
		}
	}
}