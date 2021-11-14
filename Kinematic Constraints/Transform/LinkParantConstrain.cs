using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Constrains/LinkParantConstrain")]
//[ExecuteInEditMode]
public class LinkParantConstrain : MonoBehaviour 
{
	public Transform target;

	private Vector3 difference;
	private Quaternion initRotation;

	private void Start() 
	{	
		difference = target.position - transform.position;
		initRotation = transform.rotation;
	}
	// Update is called once per frame
	private void LateUpdate () 
	{	
		if(target == null)
			return;
		
		Vector3 direction = difference.normalized;
		Vector3 rotatedOffset = target.rotation * difference; 
		transform.position = target.position - rotatedOffset;
		transform.rotation = initRotation * target.rotation;
	}
}

//  public Transform _child;
//  private Vector3 _childRelativePos;
//  private Quaternion _childInitialRot;
	
//  void Start () {
//      _childInitialRot = _child.rotation;
//      _childRelativePos = _child.position - transform.position;
//  }
	
//  void Update () {
//      _child.position = transform.rotation * _childRelativePos;
//      _child.rotation = _childInitialRot * transform.rotation;
//  }