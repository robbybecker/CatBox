using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BehaviourTreeSpace
{
	[System.Serializable]
	public class CompositeNode : BehaviourNode 
	{
		[SerializeField]
		protected BehaviourNode[] _behaviours;
		public BehaviourNode[] behaviours {
			get {
				return _behaviours;
			}
			set {
				_behaviours = value;
			}
		}

		[ContextMenu("Set Children")]
		public void SetChildren()
		{
			behaviours = new BehaviourNode[transform.childCount];
			for(int i = 0; i < transform.childCount; i++)
			{
				behaviours[i] = transform.GetChild(i).GetComponent<BehaviourNode>();
			}
		}
	}
}