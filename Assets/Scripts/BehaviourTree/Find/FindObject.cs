using UnityEngine;
using System.Collections;
using System.Linq;
using BehaviourTreeSpace;

public class FindObject : BehaviourNode
{
	public string objectToFind = "";

	public override NodeStatus Tick (TreeEntity entity)
	{
		if(objectToFind.Length == 0)
		{
			nodeStatus = NodeStatus.Failure;
			return nodeStatus;
		}
		// find object and check if it is useable
		GameObject[] objects = GameObject.FindGameObjectsWithTag(objectToFind).Where(go => go.GetComponent<IUseable>().IsObjectUsable()).ToArray();
		if(objects.Length == 0)
		{
			nodeStatus = NodeStatus.Failure;
			return nodeStatus;;
		}
		GameObject closestObject = null;
		closestObject = objects[0];			
		float distance = Vector3.Distance(entity.transform.position, closestObject.transform.position);
		for(int i = 1; i < objects.Length; i++)
		{			
			float newDistance = Vector3.Distance(entity.transform.position, objects[i].transform.position);
			if(newDistance < distance)
			{
				closestObject = objects[i];
				distance = newDistance;
			}
		}
		
		object objectPoint;
		if(entity.dataContext == null)
			entity.dataContext = new System.Collections.Generic.Dictionary<string, object>();
		if(entity.dataContext.TryGetValue("moveToLocation", out objectPoint))
		{
			entity.dataContext["moveToLocation"] = closestObject.transform.position;
		}
		else
		{
			entity.dataContext.Add("moveToLocation", closestObject.transform.position);				
		}
		
		object theObject;
		if(entity.dataContext.TryGetValue(objectToFind, out theObject))
		{
			entity.dataContext[objectToFind] = closestObject;
		}
		else
		{
			entity.dataContext.Add(objectToFind, closestObject);				
		}
		nodeStatus = NodeStatus.Success;
		return nodeStatus;
	}
}