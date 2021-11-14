using UnityEngine;

namespace Constrains
{
[AddComponentMenu("Constrains/MoveConstrain")]
[ExecuteInEditMode]
public class MoveConstrain : MonoBehaviour 
{
	public enum ConstrainAxis
	{
		xAxis,
		yAxis,
		zAxis,
		xAndY,
		xAndZ,
		yAndZ,
	}
	
	public ConstrainAxis constarin;
	public Vector3 dir;

	private Vector3 initPos;
	private Vector3 initDir;
	
	// Use this for initialization
	private void Start () 
	{
		initPos = Vector3.zero;
		initDir = transform.InverseTransformDirection(dir);
	}
	// Update is called once per frame (60 times per second)
	private void LateUpdate () 
	{
		switch(constarin)
		{
			case ConstrainAxis.xAxis:
				transform.localPosition = new Vector3(initPos.x, transform.localPosition.y, transform.position.z);
			break;
			case ConstrainAxis.yAxis:
				transform.localPosition = new Vector3(transform.localPosition.x, initPos.y, transform.localPosition.z);
			break;
			case ConstrainAxis.zAxis:
				transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, initPos.z);
			break;
			case ConstrainAxis.xAndY:
				transform.localPosition = new Vector3(initPos.x, initPos.y, transform.localPosition.z);
			break;
			case ConstrainAxis.yAndZ:
				transform.localPosition = new Vector3(transform.localPosition.x, initPos.y,  initPos.z);
			break;
			case ConstrainAxis.xAndZ:
				transform.localPosition = new Vector3(initPos.y, transform.localPosition.y, initPos.z);
			break;
		}	
	}
#if UNITY_EDITOR
	private void OnDrawGizmos() 
	{
		Gizmos.DrawRay(initPos, initDir);	
	}
#endif
}
}