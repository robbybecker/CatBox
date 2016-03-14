using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BehaviourTreeSpace
{
	[Serializable]
	public class BehaviourNode
	{
		[SerializeField]
		private string _nodeName = "";
		public string nodeName {
			get {
				return _nodeName;
			}
			set {
				_nodeName = value;
			}
		}

		[SerializeField]		
		private NodeStatus _nodeStatus;
		public NodeStatus nodeStatus {
			get {
				return _nodeStatus;
			}
			set {
				_nodeStatus = value;
			}
		}

		private bool _initialised = false;
		
		/// <summary>
		/// Called the first time a node is visited by its parent
		/// </summary>
		public virtual void EnterNode(TreeEntity entity)
		{
			entity.behaviourTree.currentNode = this;
			if(_initialised == false)
			{
				_nodeName = GetType().Name;
				_initialised = true;
				nodeStatus = NodeStatus.Running;
				OnEnterNode(entity);
			}
		}

		public virtual void OnEnterNode(TreeEntity entity){}

		public NodeStatus Process(TreeEntity entity)
		{
			EnterNode(entity);
			if(nodeStatus != NodeStatus.Running)
			{
				ExitNode(entity);
				return nodeStatus;
			}
			nodeStatus = Tick(entity);
			if(nodeStatus != NodeStatus.Running)
			{
				ExitNode(entity);
			}
			return nodeStatus;
		}

		public virtual void ExitNode(TreeEntity entity)
		{
			_initialised = false;
			OnExitNode(entity);
		}

		public virtual void OnExitNode(TreeEntity entity){}
		
		public virtual NodeStatus Tick(TreeEntity entity)
		{
			return nodeStatus;
		}
	}
}