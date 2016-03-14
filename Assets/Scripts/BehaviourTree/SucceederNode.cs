using UnityEngine;
using System.Collections;

namespace BehaviourTreeSpace
{
	/// <summary>
	/// Succeeder node - always returns success
	/// </summary>
	[System.Serializable]
	public class SucceederNode : DecoratorNode 
	{
		public override NodeStatus Tick(TreeEntity tree)
		{
			nodeStatus = NodeStatus.Success;
			_behaviour.Process(tree);		
			return NodeStatus.Success; // return the success
		}
	}
}