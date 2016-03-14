using UnityEngine;
using System.Collections;
using BehaviourTreeSpace;

[System.Serializable]
public class HungerBehaviour : RootSelector
{
	public AmIHungry amIHungry;
	public FindFood findFood;
	public EatFood eatFood;
	public MoveToLocation moveToLocation;
	public SequenceNode sequenceNode;

	public HungerBehaviour()
	{
		amIHungry = new AmIHungry();
		findFood = new FindFood();
		moveToLocation = new MoveToLocation();
		eatFood = new EatFood();
		sequenceNode = new SequenceNode(amIHungry, findFood, moveToLocation, eatFood);
		_behaviours = new BehaviourNode[]{sequenceNode};
	}
}