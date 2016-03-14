using UnityEngine;
using BehaviourTreeSpace;
using System.Collections;

[System.Serializable]
public class EatFood : BehaviourNode
{
	private Food food;
	private Hunger hunger;
	private float timer = 0f;
	
	public override void OnEnterNode (TreeEntity entity)
	{
		timer = 0f;
		object outObject;
		if(entity.dataContext.TryGetValue("foodToEat", out outObject))
		{
			if(outObject == null)
			{
				nodeStatus = NodeStatus.Failure;			
			}
			else
			{
				food = ((GameObject)outObject).GetComponent<Food>();
				hunger = entity.GetComponent<Hunger>();
			}
		}
		else
		{
			nodeStatus = NodeStatus.Failure;			
		}
	}

	public override NodeStatus Tick (TreeEntity entity)
	{
		if(food == null)
		{
			nodeStatus = NodeStatus.Failure;			
			return nodeStatus;
		}
		timer += Time.deltaTime;
		if(timer >= 0.1f)
		{
			entity.GetComponent<Hunger>().Eat(food);
			timer = 0f;
			nodeStatus = NodeStatus.Running;			
		}
		if(hunger.hungerState == HungerState.Full || food.quantity == 0)
		{
			nodeStatus = NodeStatus.Success;
		}
		return nodeStatus;
	}
}