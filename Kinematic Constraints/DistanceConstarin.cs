using UnityEngine;

namespace Constrains
{
[AddComponentMenu("Constrains/DistanceConstarin")]
[ExecuteInEditMode]
public class DistanceConstarin : MonoBehaviour 
{
	public float minDistance = 0;
	public float maxDistance = 1;
	public Transform target;
	private Vector3 difference;

	// Use this for initialization
	private void Start () 
	{
		
	}
	
	// Update is called once per frame (60 times per second)
	private void LateUpdate () 
	{
		if(target == null)
			return;

		Vector3 difference = target.position - transform.position;
		// normalize to only get a direction with magnitude = 1
		Vector3 direction = difference.normalized;
		// here you "clamp" use the smaller of either
		// the max radius or the magnitude of the difference vector
		float distance = 0;
		// if(useLimits)
		// {
			distance = Mathf.Clamp(difference.magnitude, minDistance, maxDistance);
		// }
		// else
		// {
		// 	distance = difference.magnitude;
		// }
		// and finally apply the end position
		Vector3 endPosition = target.position - direction * distance;
		transform.position = endPosition;
	}
}
}