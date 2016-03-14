using UnityEngine;
using System.Collections;

public class Need : MonoBehaviour 
{
	[SerializeField]
	protected float _interval = 1f;
	public float interval {
		get {
			return _interval;
		}
		set {
			_interval = value;
		}
	}

	public int initialNeedLevel = 60;
	public int maxNeedLevel = 100;
	
	protected int _needLevel = 60;
	public int needLevel {
		get {
			return _needLevel;
		}
		set {
			_needLevel = value;
			CheckNeedLevels();			
		}
	}

	void Start ()
	{
		OnStart();
		needLevel = initialNeedLevel;
		CheckNeedLevels();
		StartCoroutine(Process());
	}
	protected virtual void OnStart(){}

	void Update () 
	{
		OnUpdate();
	}
	protected virtual void OnUpdate(){}

	IEnumerator Process()
	{
		while(true)
		{
			yield return new WaitForSeconds(interval);
			ProcessNeed();
		}
	}
	protected virtual void ProcessNeed()
	{
		needLevel = Mathf.Clamp(needLevel - 1, 0, maxNeedLevel);		
	}

	protected virtual void CheckNeedLevels(){}
}