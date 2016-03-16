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
		public override NodeStatus Tick(TreeEntity entity)
		{
			behaviour.Process(entity);		
			nodeStatus = NodeStatus.Success;
			return nodeStatus; // return the success
		}
	}
}