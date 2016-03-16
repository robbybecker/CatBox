﻿using UnityEngine;
using System.Collections;

public class Food : Consumable 
{
	protected override bool OnUseObject (BehaviourTreeSpace.TreeEntity entity)
	{
		return entity.GetComponent<Hunger>().AddNeed();
	}
}