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
		public RandomSelector(params BehaviourNode[] behaviours)
		{
			_behaviours = behaviours;
		}
		
		public override NodeStatus Tick(TreeEntity tree)
		{
			_behaviours.Shuffle();
			return base.Tick(tree);
		}
	}
}