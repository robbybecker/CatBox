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
		public int maxCount = 2; // set a repeat amount
		private int _counter = 0;

		public override void OnEnterNode (TreeEntity entity)
		{
			_counter = 0;
		}

		public override NodeStatus Tick (TreeEntity tree)
		{
			while(_counter < maxCount)
			{
				nodeStatus = behaviour.Process(tree);
				if(nodeStatus != NodeStatus.Success && nodeStatus != NodeStatus.Failure)
					return nodeStatus;

				_counter++;
			}
			nodeStatus = NodeStatus.Success;
			return nodeStatus;
		}
	}
}