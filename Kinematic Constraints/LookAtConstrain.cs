/*
 * Modified template by Unity Support.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Constrains
{
[AddComponentMenu("Constrains/LookAtConstrain")]
[ExecuteInEditMode]
public class LookAtConstrain : MonoBehaviour 
{
#region Public Fields
	public Transform target;

	public LoockAxis loockAxis;

	public enum LoockAxis
	{
		x,
		y,
		z,
	}
#endregion

#region Unity Methods
	private void Update ()
	{
		if (target == null)
			return;

		var dir = target.position - transform.position;
		//dir = transform.InverseTransformDirection(dir);
		transform.rotation = Quaternion.FromToRotation(ReturnAxis(), dir);
	}
	private Vector3 ReturnAxis()
	{
		Vector3 axis = Vector3.zero;
		switch(loockAxis)
		{
			case LoockAxis.x:
				axis = Vector3.right;
			break;
			case LoockAxis.y:
				axis = Vector3.up;
			break;
			case LoockAxis.z:
				axis = Vector3.forward;
			break;
		}
		return axis;
	}
#endregion
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
