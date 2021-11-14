using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Constrains/ScaleConstrain")]
public class ScaleConstrain : MonoBehaviour 
{
	public Transform target;

	private Vector3 initScaleDiff;

	// Use this for initialization
	private void Start () 
	{
		initScaleDiff = target.localScale - transform.localScale;
	}
	
	// Update is called once per frame (60 times per second)
	private void LateUpdate () 
	{
		if(target == null)
			return;

		transform.localScale = target.localScale + initScaleDiff;
	}
}
