using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Constrains
{
[AddComponentMenu("Constrains/RelationConstrain")]
public class RelationConstrain : MonoBehaviour 
{
	[SerializeField]
	private Transform target;
	[SerializeField]
	private AnimationCurve waith = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 1f));

	[SerializeField, HideInInspector]
	private Vector3 thisPos1;
	[SerializeField, HideInInspector]
	private Vector3 thisPos2;
	[SerializeField, HideInInspector]
	private Vector3 thisRot1;
	[SerializeField, HideInInspector]
	private Vector3 thisRot2;

	[SerializeField, HideInInspector]
	private Vector3 posTarget1;
	[SerializeField, HideInInspector]
	private Vector3 posTarget2;

#if UNITY_EDITOR
	[HideInInspector]
	public bool editMode = false;
#endif

	// Use this for initialization
	private void Start () 
	{
		
	}
	
	// Update is called once per frame (60 times per second)
	private void Update () 
	{
		float percent = GetPercentageAlong(posTarget1, posTarget2, target.position);
		transform.eulerAngles = Vector3.Lerp(thisRot1, thisRot2, waith.Evaluate(percent));
		transform.position = Vector3.Lerp(thisPos1, thisPos2, waith.Evaluate(percent));
	}
	public float GetPercentageAlong(Vector3 a, Vector3 b, Vector3 current)
	{
		var ab = b - a;
		var ac = current - a;
		return Vector3.Dot(ac, ab.normalized) / ab.magnitude;
	}

	public void SetPosOne()
	{
		posTarget1 = target.position;
		thisPos1 = transform.position;
		thisRot1 = transform.eulerAngles;
	}
	public void SetPosTwo()
	{
		posTarget2 = target.position;
		thisPos2 = transform.position;
		thisRot2 = transform.eulerAngles;
	}

	public void ResetPosition()
	{
		target.position = posTarget1;
		transform.position = thisPos1;
		transform.eulerAngles = thisRot1;
	}
	public void BackUpPosition()
	{
		// target.position = posTarget1;
		// transform.position = thisPos1;
		// transform.eulerAngles = thisRot1;
	}

#if UNITY_EDITOR
	private void OnDrawGizmos() 
	{
		if (target == null)
			return;

		UnityEditor.Handles.DrawDottedLine(transform.position, target.position, 10f);
	}
#endif

}
}