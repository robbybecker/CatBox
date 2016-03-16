using UnityEngine;
using System.Collections;
using System;

namespace BehaviourTreeSpace
{
	[Serializable]
	/// <summary>
	/// Repeater node - repeats the child node a set amount of times
	/// </summary>
	public class RepeaterNode : DecoratorNode
	{
		private int _maxCount = 2; // set a repeat amount
		private int _counter = 0;

		public RepeaterNode(int maxCount, BehaviourNode behaviour)
		{
			behaviour = behaviour;
			_maxCount = maxCount;
		}

		public override NodeStatus Tick (TreeEntity tree)
		{
			nodeStatus = behaviour.Process(tree);
			if(nodeStatus == NodeStatus.Failure)
				return nodeStatus;
			if (_counter < _maxCount)
			{
				_counter++;
				nodeStatus = NodeStatus.Running;
			}
			else
			{
				_counter = 0;
				nodeStatus = NodeStatus.Success;
			}
			return nodeStatus;
		}
	}
}