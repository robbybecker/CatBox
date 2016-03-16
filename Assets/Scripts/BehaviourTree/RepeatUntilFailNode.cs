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
			while(behaviour.Process(tree) != NodeStatus.Failure){}
			return NodeStatus.Success;
		}
	}
}