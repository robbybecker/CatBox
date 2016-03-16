using UnityEngine;
using System.Collections;

namespace BehaviourTreeSpace
{
	[System.Serializable]
	/// <summary>
	/// Sequence node - runs a sequence of child nodes
	/// </summary>
	public class SequenceNode : CompositeNode 
	{
		public override NodeStatus Tick(TreeEntity tree)
		{
			for(int i = 0; i < _behaviours.Length; i++)
			{
				nodeStatus = _behaviours[i].Process(tree);
				if(nodeStatus == NodeStatus.Failure)
					return nodeStatus;
				else if(nodeStatus == NodeStatus.Success)
					continue; // continue to next
				else if(nodeStatus == NodeStatus.Running)
					break; // stop at this node to process the running
			}
			return nodeStatus;
		}
	}
}