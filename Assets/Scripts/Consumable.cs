using UnityEngine;
using System.Collections;

public class Consumable : MonoBehaviour, IUseable
{
	[SerializeField]
	protected int _quantity = 10;
	public int quantity {
		get {
			return _quantity;
		}
		set {
			_quantity = value;
		}
	}

	protected float timer = 0f;

	public bool IsObjectUsable()
	{
		return (quantity > 0);
	}

	public bool UseObject(BehaviourTreeSpace.TreeEntity entity)
	{
		if(quantity == 0)
		{
			return true;
		}
		timer += Time.deltaTime;
		if(timer >= 0.1f)
		{
			quantity--;
			timer = 0f;
			return OnUseObject(entity);
		}
		return false;
	}
	protected virtual bool OnUseObject(BehaviourTreeSpace.TreeEntity entity)
	{
		return false;
	}
	
	void Awake()
	{
		quantity = Random.Range(100, 300);
	}
}