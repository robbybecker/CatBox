using UnityEngine;
using System.Collections;

public interface IUseable 
{
	bool IsObjectUsable();
	bool UseObject(BehaviourTreeSpace.TreeEntity entity);
}