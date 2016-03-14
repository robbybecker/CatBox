using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BehaviourTreeSpace
{
	public class TreeEntity : MonoBehaviour 
	{
		[SerializeField]
		private BehaviourTree _behaviourTree;	
		public BehaviourTree behaviourTree {
			get {
				return _behaviourTree;
			}
			set {
				_behaviourTree = value;
			}
		}
		public Dictionary<string, object> dataContext = new Dictionary<string, object>();		
		protected RootSelector root;

		void Start()
		{
			OnStart();
			if(root != null)
				behaviourTree.Setup(root);
		}
		public virtual void OnStart(){}

		void Update()
		{
			OnUpdate();
			if(behaviourTree != null)
				behaviourTree.Process();
		}
		public virtual void OnUpdate(){}
	}
}