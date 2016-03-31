using UnityEngine;
using System.Collections;
using System;

namespace BehaviourTreeSpace
{
	[Serializable]
	public class RootSelector : CompositeNode 
	{	
		public override NodeStatus OnTick (TreeEntity tree)
		{
			NodeStatus nodeStatus = _behaviours[0].Process(tree);
			return nodeStatus;
		}
	}
}