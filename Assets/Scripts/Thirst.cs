using UnityEngine;
using System.Collections;

public class Thirst : PhysicalNeed 
{
	protected override void OnAddNeed ()
	{
		GetComponent<Bladder>();
	}
}