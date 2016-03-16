using UnityEngine;
using System;
using System.Collections;

namespace BehaviourTreeSpace
{
	public enum NodeStatus
	{
		Fresh = 0,
		Success = 1,
		Failure = 2,
		Running = 3,
		Cancelled = 4,
		Error = 5
	}

	[Serializable]
	public class BehaviourTree : MonoBehaviour
	{
//		public BehaviourTree(BehaviourNode rootNode)
//		{
//			_rootNode = (RootSelector)rootNode;	
//			_currentNode = rootNode;	
//		}
//
//		public void Setup(BehaviourNode rootNode)
//		{
//			_rootNode = (RootSelector)rootNode;	
//			_currentNode = rootNode;	
//		}
//
//		public NodeStatus Process(TreeEntity entity)
//		{
//			NodeStatus nodeStatus = entity.currentNode.Process(entity);
//			if(nodeStatus != NodeStatus.Running)
//				_rootNode.Process(entity);
//
//			return nodeStatus;
//		}
	}
}