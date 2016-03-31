using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BehaviourTreeSpace
{
	[Serializable]
	public struct BehaviourNodeInfo
	{
		public string nodeName;			
		public NodeStatus nodeStatus;	
		public bool initialised;

		public BehaviourNodeInfo(string nodeName, NodeStatus nodeStatus, bool initialised)
		{
			this.nodeName = nodeName;
			this.nodeStatus = nodeStatus;
			this.initialised = initialised;
		}
	}

//	[Serializable]
//	public struct BehaviourNodeInfo
//	{
//		public NodeStatus nodeStatus;	
//		public bool initialised;
//		
//		public BehaviourNodeInfo(NodeStatus nodeStatus, bool initialised)
//		{
//			this.nodeStatus = nodeStatus;
//			this.initialised = initialised;
//		}
//	}

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

//		[SerializeField]		
//		private NodeStatus _nodeStatus;
//		public NodeStatus nodeStatus {
//			get {
//				return _nodeStatus;
//			}
//			set {
//				_nodeStatus = value;
//			}
//		}
//
//		private bool _initialised = false;
//		public bool initialised {
//			get {
//				return _initialised;
//			}
//			set {
//				_initialised = value;
//			}
//		}

		private int _uid;
		public int uid {
			get {
				return _uid;
			}
			set {
				_uid = value;
			}
		}
		
		void Awake()
		{
			uid = GetInstanceID();
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
			if(entity.EnterNode(this))
			{
				OnEnterNode(entity);
			}
		}

		public virtual void OnEnterNode(TreeEntity entity){}

		public NodeStatus Process(TreeEntity entity)
		{
			EnterNode(entity);
//			if(nodeStatus != NodeStatus.Running)
//			{
//				ExitNode(entity);
//				return entity.nodeStatus;
//			}
			NodeStatus nodeStatus = Tick(entity);
			entity.TickNode(this, nodeStatus);
			if(nodeStatus != NodeStatus.Running)
			{
				ExitNode(entity, nodeStatus);
			}
			return nodeStatus;
		}
		/// <summary>
		/// Called at end of node processing
		/// </summary>
		/// <param name="entity">Entity.</param>
		public void ExitNode(TreeEntity entity, NodeStatus nodeStatus)
		{
			entity.ExitNode(this, nodeStatus);
			OnExitNode(entity, nodeStatus);
		}

		public virtual void OnExitNode(TreeEntity entity, NodeStatus nodeStatus){}

		public virtual NodeStatus Tick(TreeEntity entity)
		{
			return OnTick(entity);
		}

		/// <summary>
		/// Tick the specified node with the supplied entity.
		/// </summary>
		/// <param name="entity">Entity.</param>
		public virtual NodeStatus OnTick(TreeEntity entity)
		{
			return NodeStatus.Running;
		}
	}
}