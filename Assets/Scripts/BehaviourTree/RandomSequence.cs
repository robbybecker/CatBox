using UnityEngine;
using System.Collections;

namespace BehaviourTreeSpace
{
	[System.Serializable]
	/// <summary>
	/// Sequence node - runs a sequence of child nodes in random order
	/// </summary>
	public class RandomSequence : SequenceNode 
	{
		public override NodeStatus Tick(TreeEntity tree)
		{
			_behaviours.Shuffle();
			return base.Tick(tree);
		}
	}
}