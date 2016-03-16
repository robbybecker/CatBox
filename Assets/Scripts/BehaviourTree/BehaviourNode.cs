using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BehaviourTreeSpace
{
	[Serializable]
	public class BehaviourNode : MonoBehaviour
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

		void Awake()
		{
			nodeStatus = NodeStatus.Fresh;
		}

		void OnValidate()
		{
			if(nodeName.Length == 0)
			{
				nodeName = this.GetType().Name;
				gameObject.name = nodeName;
			}
			else
			{
				gameObject.name = nodeName;				
			}
		}
		
		/// <summary>
		/// Called the first time a node is visited by its parent
		/// </summary>
		public virtual void EnterNode(TreeEntity entity)
		{
			entity.currentNode = this;
			if(_initialised == false)
			{
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
		/// <summary>
		/// Called at end of node processing
		/// </summary>
		/// <param name="entity">Entity.</param>
		public virtual void ExitNode(TreeEntity entity)
		{
			_initialised = false;
			OnExitNode(entity);
		}

		public virtual void OnExitNode(TreeEntity entity){}

		/// <summary>
		/// Tick the specified node with the supplied entity.
		/// </summary>
		/// <param name="entity">Entity.</param>
		public virtual NodeStatus Tick(TreeEntity entity)
		{
			return nodeStatus;
		}
	}
}