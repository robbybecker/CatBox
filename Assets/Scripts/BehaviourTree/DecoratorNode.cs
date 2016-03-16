using UnityEngine;
using System.Collections;

namespace BehaviourTreeSpace
{
	/// <summary>
	/// Decorator node - one child node, modifies that child somehow
	/// </summary>
	public class DecoratorNode : BehaviourNode
	{
		[SerializeField]
		private BehaviourNode _behaviour;
		public BehaviourNode behaviour {
			get {
				return _behaviour;
			}
			set {
				_behaviour = value;
			}
		}

		[ContextMenu("Set Child")]
		public void SetChild (DecoratorNode node) 
		{
			if(node.transform.childCount == 0)
				return;
			node.behaviour = node.transform.GetChild(0).GetComponent<BehaviourNode>();
		}
	}
}