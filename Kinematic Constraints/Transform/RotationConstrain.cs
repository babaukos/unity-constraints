using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Constrains/RotationConstrain")]

public class RotationConstrain : MonoBehaviour 
{
	public Transform target;

	private Vector3 difference;
	private Quaternion initRotation;

	// Use this for initialization
	private void Start () 
	{
		difference = target.position - transform.position;
		initRotation = transform.rotation;
	}
	
	// Update is called once per frame (60 times per second)
	private void LateUpdate () 
	{
		if(target == null)
			return;
		
		// Vector3 direction = difference.normalized;
		// Vector3 rotatedOffset = target.rotation * difference; 
		// transform.position = target.position - rotatedOffset;
		transform.rotation = initRotation * target.rotation;
	}
}
