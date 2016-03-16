using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BehaviourTreeSpace
{
	public class TreeEntity : MonoBehaviour 
	{
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

		public Dictionary<string, object> dataContext = new Dictionary<string, object>();

		[SerializeField]
		protected RootSelector _rootNode;
		public RootSelector rootNode {
			get {
				return _rootNode;
			}
			set {
				_rootNode = value;
			}
		}

		void Start()
		{
			OnStart();
			currentNode = rootNode;
		}
		public virtual void OnStart(){}

		void Update()
		{
			OnUpdate();
			NodeStatus nodeStatus = currentNode.Process(this);
			if(nodeStatus != NodeStatus.Running)
				rootNode.Process(this);
		}
		public virtual void OnUpdate(){}
	}
}