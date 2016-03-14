using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BehaviourTreeSpace
{
	[Serializable]
	public class CompositeNode : BehaviourNode 
	{
		protected BehaviourNode[] _behaviours;

		public CompositeNode(params BehaviourNode[] behaviours)
		{
			_behaviours = behaviours;
		}
	}
}