using UnityEngine;
using System.Collections;

public enum HungerState
{
	StarvingToDeath,
	Starving,
	Hungry, 
	Satiated, 
	Full, 
	Gorged 
}

public class Hunger : PhysicalNeed 
{
	[SerializeField]
	private HungerState _hungerState;
	public HungerState hungerState {
		get {
			return _hungerState;
		}
		set {
			_hungerState = value;
		}
	}

	protected override void CheckNeedLevels ()
	{
		if(needLevel <= 0)
		{
			hungerState = HungerState.StarvingToDeath;
		}
		else if(needLevel <= 30)
		{
			hungerState = HungerState.Starving;
		}
		else if(needLevel <= 60)
		{
			hungerState = HungerState.Hungry;			
		}
		else if(needLevel <= 80)
		{
			hungerState = HungerState.Satiated;			
		}
		else if(needLevel <= 90)
		{
			hungerState = HungerState.Full;			
		}
		else if(needLevel <= 100)
		{
			hungerState = HungerState.Gorged;			
		}
	}

	public void Eat(Food food)
	{
		if(food.quantity > 0)
		{
			food.quantity--;
			needLevel = Mathf.Clamp(needLevel + 1, 0, maxNeedLevel);	
		}
	}
}