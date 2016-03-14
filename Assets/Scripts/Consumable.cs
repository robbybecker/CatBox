using UnityEngine;
using System.Collections;

public class Consumable : MonoBehaviour 
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

	void Awake()
	{
		quantity = Random.Range(10, 30);
	}
}