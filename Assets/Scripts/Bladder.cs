using UnityEngine;
using System.Collections;

public class Bladder : PhysicalNeed
{
	int drinkVolume = 0;

	public void HadADrink()
	{
		drinkVolume++;
	}

	protected override void ProcessNeed ()
	{
		if(drinkVolume > 0)
		{
			drinkVolume--;
			needLevel = Mathf.Clamp(needLevel - 1, 0, maxNeedLevel);
		}
	}
}