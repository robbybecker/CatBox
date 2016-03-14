using UnityEngine;
using System;
using System.Collections;

namespace BehaviourTreeSpace
{
	public enum NodeStatus
	{
		Success = 0,
		Failure = 1,
		Running = 2,
		Cancelled = 3
	}

	[Serializable]
	public class BehaviourTree
	{
		[SerializeField]
		private RootSelector _rootNode;
		public RootSelector rootNode {
			get {
				return _rootNode;
			}
			set {
				_rootNode = value;
			}
		}

		[SerializeField]
		private BehaviourNode _currentNode;
		public BehaviourNode currentNode {
			get {
				return _currentNode;
			}
			set {
				_previousNode = _currentNode;
				_currentNode = value;
			}
		}
		private BehaviourNode _previousNode;

		[SerializeField]
		private TreeEntity _entity;
		public TreeEntity entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public BehaviourTree(BehaviourNode rootNode)
		{
			_rootNode = (RootSelector)rootNode;	
			_currentNode = rootNode;	
		}

		public void Setup(BehaviourNode rootNode)
		{
			_rootNode = (RootSelector)rootNode;	
			_currentNode = rootNode;	
		}

		public NodeStatus Process()
		{
			NodeStatus nodeStatus = _currentNode.Process(entity);
			if(nodeStatus != NodeStatus.Running)
				_rootNode.Process(entity);

			return nodeStatus;
		}
	}
}