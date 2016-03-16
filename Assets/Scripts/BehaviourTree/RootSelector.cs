using UnityEngine;
using System.Collections;
using System;

namespace BehaviourTreeSpace
{
	[Serializable]
	public class RootSelector : CompositeNode 
	{	
		public override NodeStatus Tick (TreeEntity tree)
		{
			NodeStatus returnStatus = NodeStatus.Running;
			returnStatus = _behaviours[0].Process(tree);
			return returnStatus;
		}
	}
}