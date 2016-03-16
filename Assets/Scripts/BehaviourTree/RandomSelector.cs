using UnityEngine;
using System.Collections;

namespace BehaviourTreeSpace
{
	[System.Serializable]
	/// <summary>
	/// Random selector.
	/// </summary>
	public class RandomSelector : SelectorNode
	{		
		public override NodeStatus Tick(TreeEntity tree)
		{
			if(nodeStatus != NodeStatus.Running)
				_behaviours.Shuffle();
			return base.Tick(tree);
		}
	}
}