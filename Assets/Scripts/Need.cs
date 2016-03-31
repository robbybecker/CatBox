using UnityEngine;
using System.Collections;

public enum NeedState
{
	Terrible,	
	Bad,
	Okay,
	Good,
	Great
}

public class Need : MonoBehaviour 
{
	[SerializeField]
	[Tooltip("Interval in seconds the need decreases at")]
	protected float _interval = 1f;
	public float interval {
		get {
			return _interval;
		}
		set {
			_interval = value;
		}
	}
//	[Header("Need Settings")]
	public int initialNeedLevel = 60;
	public int maxNeedLevel = 100;
	
	[SerializeField]
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

	[SerializeField]
	protected NeedState _needState;
	public NeedState needState {
		get {
			return _needState;
		}
		set {
			_needState = value;
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

	protected virtual void CheckNeedLevels()
	{
		if(needLevel <= 10)
		{
			needState = NeedState.Terrible;
		}
		else if(needLevel <= 30)
		{
			needState = NeedState.Bad;
		}
		else if(needLevel <= 60)
		{
			needState = NeedState.Okay;
		}
		else if(needLevel <= 80)
		{
			needState = NeedState.Good;
		}
		else if(needLevel <= 100)
		{
			needState = NeedState.Great;
		}
	}

	public bool DoWeNeedTheNeed()
	{
		if(needState == NeedState.Terrible || needState == NeedState.Bad)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool AddNeed()
	{
		needLevel = Mathf.Clamp(needLevel + 1, 0, maxNeedLevel);	
		OnAddNeed();
		if(needState == NeedState.Good || needState == NeedState.Great)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	protected virtual void OnAddNeed(){}
}
