using UnityEngine;
using System.Collections;
using BehaviourTreeSpace;

public class Cat : TreeEntity 
{
	public override void OnStart ()
	{
//		SelectorNode selectorNode = new SelectorNode(new HungerBehaviour(), new ThirstyBehaviour());
		RandomSelector selectorNode = new RandomSelector(new HungerBehaviour(), new ThirstyBehaviour());
		root  = new RootSelector(selectorNode);
	}
}