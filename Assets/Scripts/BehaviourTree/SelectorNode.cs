﻿using UnityEngine;
using System;
using System.Collections;

namespace BehaviourTreeSpace
{
	[Serializable]
	/// <summary>
	/// Selector node - basically an Or gate, returns when one child reports success
	/// </summary>
	public class SelectorNode : CompositeNode
	{	
		public SelectorNode(params BehaviourNode[] behaviours)
		{
			_behaviours = behaviours;
		}

		public override NodeStatus Tick(TreeEntity tree)
		{
			for(int i = 0; i < _behaviours.Length; i++)
			{
				nodeStatus = _behaviours[i].Process(tree);
				if(nodeStatus == NodeStatus.Success)
					return nodeStatus; // return success
				else if(nodeStatus == NodeStatus.Running)
					break; // stop at this node to process the running
			}
			return nodeStatus;
		}
	}
}