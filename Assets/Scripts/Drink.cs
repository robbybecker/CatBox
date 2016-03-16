using UnityEngine;
using System.Collections;

public class Drink : Consumable
{
	protected override bool OnUseObject(BehaviourTreeSpace.TreeEntity entity)
	{
		return entity.GetComponent<Thirst>().AddNeed();
	}
}