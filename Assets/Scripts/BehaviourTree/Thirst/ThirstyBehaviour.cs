using UnityEngine;
using System.Collections;
using BehaviourTreeSpace;

[System.Serializable]
public class ThirstyBehaviour : RootSelector 
{
	public AmIThirsty amIThirsty;
	public FindDrink findDrink;
	public DrinkTheDrink drinkTheDrink;
	public MoveToLocation moveToLocation;
	public SequenceNode sequenceNode;
	
	public ThirstyBehaviour()
	{
		amIThirsty = new AmIThirsty();
		findDrink = new FindDrink();
		moveToLocation = new MoveToLocation();
		drinkTheDrink = new DrinkTheDrink();
		sequenceNode = new SequenceNode(amIThirsty, findDrink, moveToLocation, drinkTheDrink);
		_behaviours = new BehaviourNode[]{sequenceNode};
	}
}