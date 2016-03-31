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
		public override NodeStatus OnTick(TreeEntity entity)
		{
			behaviour.Process(entity);		
			return NodeStatus.Success; // return the success
		}
	}
}