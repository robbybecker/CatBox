using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BehaviourTreeSpace
{
	public class TreeEntity : MonoBehaviour , ISerializationCallbackReceiver
	{
		[SerializeField]
		private BehaviourNode _currentNode;
		public BehaviourNode currentNode {
			get {
				return _currentNode;
			}
			set {
				_currentNode = value;
			}
		}

		private int _uid;
		public int uid {
			get {
				return _uid;
			}
			set {
				_uid = value;
			}
		}

		public Dictionary<int, BehaviourNodeInfo> nodes = new Dictionary<int, BehaviourNodeInfo>();

		public List<int> _keys;
		public List<BehaviourNodeInfo> _values;
		public void OnBeforeSerialize()
		{
			_keys.Clear();
			_values.Clear();
			foreach(var kvp in nodes)
			{
				_keys.Add(kvp.Key);
				_values.Add(kvp.Value);
			}
		}

		public void OnAfterDeserialize()
		{
			nodes.Clear();
			for (int i=0; i!= System.Math.Min(_keys.Count,_values.Count); i++)
				nodes.Add(_keys[i],_values[i]);
		}

		public Dictionary<string, Vector3> dataContextVector = new Dictionary<string, Vector3>();
		public Dictionary<string, GameObject> dataContextGameObject = new Dictionary<string, GameObject>();

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

//		private System.Threading.Thread _thread = null;
//		private void Run()
//		{
//			System.Threading.Thread.Sleep(1000);
//			t_position = position;
//		}
		void Awake()
		{
			uid = GetInstanceID();
		}

		void Start()
		{
			OnStart();		
//			_thread = new System.Threading.Thread(Run);
//			_thread.Start();
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

		public bool EnterNode(BehaviourNode node)
		{
			if(nodes.ContainsKey(node.uid) == false)
			{
				nodes.Add(node.uid, new BehaviourNodeInfo(node.nodeName, NodeStatus.Fresh, false));
			}
			if(nodes[node.uid].initialised == false)
			{
				BehaviourNodeInfo info = nodes[node.uid];
				info.initialised = true;
				info.nodeStatus = NodeStatus.Running;
				nodes[node.uid] = info;
				return true;
			}
			return false; // if we have already initialised the node return false
		}

		public void TickNode(BehaviourNode node, NodeStatus nodeStatus)
		{
			BehaviourNodeInfo info = nodes[node.uid];
			info.nodeStatus = nodeStatus;
			nodes[node.uid] = info;
		}

		public void ExitNode(BehaviourNode node, NodeStatus nodeStatus)
		{
			BehaviourNodeInfo info = nodes[node.uid];
			info.initialised = false;
			info.nodeStatus = nodeStatus;
			nodes[node.uid] = info;
		}
	}
}