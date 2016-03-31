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
		public override void OnEnterNode (TreeEntity entity)
		{
			_behaviours.Shuffle();
		}
	}
}