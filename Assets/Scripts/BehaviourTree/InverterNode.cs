using UnityEngine;
using System.Collections;
using System;

namespace BehaviourTreeSpace
{
	[Serializable]
	/// <summary>
	/// Inverter node - inverts the result of the child node
	/// </summary>
	public class InverterNode : DecoratorNode 
	{
		public override NodeStatus Tick (TreeEntity tree)
		{
			nodeStatus = behaviour.Process(tree);

			if(nodeStatus == NodeStatus.Failure)
				nodeStatus = NodeStatus.Success;
			else if(nodeStatus == NodeStatus.Success)
				nodeStatus = NodeStatus.Failure;	

			return nodeStatus;
		}
	}
}