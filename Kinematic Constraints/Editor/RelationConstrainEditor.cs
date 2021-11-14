using UnityEngine;
using UnityEditor;
using Constrains;

[CustomEditor(typeof(RelationConstrain)), CanEditMultipleObjects]
public class RelationConstrainEditor : Editor 
{
	private RelationConstrain relationConstrain;

	private void OnEnable() 
	{
		relationConstrain = (RelationConstrain)target;
	}
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		GUI.enabled = relationConstrain.editMode;
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("Set Pos 1"))
		{
			relationConstrain.SetPosOne();
		}
		if(GUILayout.Button("Set Pos 2"))
		{
			relationConstrain.SetPosTwo();
		}
		GUILayout.EndHorizontal();
		GUI.enabled = true;

		string buttonFunc = relationConstrain.editMode == true ? "end edit": "start edit"; 
		if(GUILayout.Button(buttonFunc))
		{
			if(relationConstrain.editMode)
			{
				relationConstrain.ResetPosition();
			}
			// else
			// {
			// 	relationConstrain.ResetPosition();
			// }
			relationConstrain.editMode =!relationConstrain.editMode;	
		}
	}
}