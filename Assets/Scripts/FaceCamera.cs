using UnityEngine;
using System.Collections;

public class FaceCamera : MonoBehaviour
{
	[SerializeField]
	private Vector3 _myRotation = new Vector3(0, 0, 0);

	[SerializeField]
	private bool updateEachFrame = false;

	void Start()
	{
		SetRot();		
	}

	void Update () 
	{
		if(updateEachFrame)
			SetRot();
	}

	void SetRot()
	{
		transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward) * Quaternion.Euler(_myRotation);		
	}
}