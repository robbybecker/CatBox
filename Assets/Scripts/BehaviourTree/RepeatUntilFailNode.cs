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
		public override NodeStatus Tick (TreeEntity tree)
		{
	//		NodeStatus returnStatus = NodeStatus.Success;
	//		while(returnStatus == NodeStatus.Running || returnStatus == NodeStatus.Success)
	//		{
	//			returnStatus = _behaviour.Tick(tree);
	//		}
	//		return NodeStatus.Success;

			while(_behaviour.Process(tree) != NodeStatus.Failure){}

			return NodeStatus.Success;


	//		NodeStatus returnStatus = _behaviour.Tick(tree);
	//		if (returnStatus == NodeStatus.Running || returnStatus == NodeStatus.Success)
	//		{
	//
	//		}
	//		return returnStatus;
		}
	}
}