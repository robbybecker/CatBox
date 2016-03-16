using UnityEngine;
using System.Collections;

public class CatLitter : Consumable
{
	protected override bool OnUseObject (BehaviourTreeSpace.TreeEntity entity)
	{
		return entity.GetComponent<Bladder>().AddNeed();
	}
}