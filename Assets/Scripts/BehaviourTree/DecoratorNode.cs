using UnityEngine;
using System.Collections;

namespace BehaviourTreeSpace
{
	public class DecoratorNode : BehaviourNode
	{
		protected BehaviourNode _behaviour;

		public DecoratorNode()
		{
		}

		public DecoratorNode(BehaviourNode behaviour)
		{
			_behaviour = behaviour;
		}
	}
}