using UnityEngine;
using System.Collections;

public enum ThirstState
{
	DyingOfThirst,
	Dehydrated,
	Parched,
	Thirsty,
	Quenched,
	Hydrated
}

public class Thirst : PhysicalNeed 
{
	[SerializeField]
	private ThirstState _thirstState;
	public ThirstState thirstState {
		get {
			return _thirstState;
		}
		set {
			_thirstState = value;
		}
	}
	
	protected override void CheckNeedLevels ()
	{
		if(needLevel <= 0)
		{
			thirstState = ThirstState.DyingOfThirst;
		}
		else if(needLevel <= 30)
		{
			thirstState = ThirstState.Dehydrated;
		}
		else if(needLevel <= 55)
		{
			thirstState = ThirstState.Parched;			
		}
		else if(needLevel <= 75)
		{
			thirstState = ThirstState.Thirsty;			
		}
		else if(needLevel <= 90)
		{
			thirstState = ThirstState.Quenched;			
		}
		else if(needLevel <= 100)
		{
			thirstState = ThirstState.Hydrated;			
		}
	}

	public void Drink(Drink drink)
	{
		if(drink.quantity > 0)
		{
			drink.quantity--;
			needLevel = Mathf.Clamp(needLevel + 1, 0, maxNeedLevel);	
		}
	}
}