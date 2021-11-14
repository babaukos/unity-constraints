using UnityEngine;

namespace Constrains
{
[AddComponentMenu("Constrains/OrientConstrain")]
[ExecuteInEditMode]
public class OrientConstrain : MonoBehaviour 
{
	public Transform trans1;
	public Transform trans2;

	public OrientType orientType;

	private Vector3 targetPos;
	public enum OrientType
	{
		position,
		direction,
	}

	// Use this for initialization
	private void Start () 
	{
		
	}
	
	// Update is called once per frame (60 times per second)
	private void Update () 
	{
		if(trans1 == null || trans2 == null)
			return;

		switch(orientType)
		{
			case OrientType.position:
				targetPos = (trans1.position + trans2.position) / 2;
				transform.position = targetPos;
			break;
			case OrientType.direction:
				targetPos = (trans1.position + trans2.position) / 2;
				Vector3 direction = targetPos - transform.position;
				transform.forward = direction;
			break;
		}
	}
}
}