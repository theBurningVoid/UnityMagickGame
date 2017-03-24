using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(RoomGenScript))]
public class RoomGenEditor : Editor {

	public override void OnInspectorGUI (){
		DrawDefaultInspector ();
		RoomGenScript genScript = (RoomGenScript)target;

		if (GUILayout.Button ("Generate Room")) {
			genScript.GenerateRoom ();
		}
		if (GUILayout.Button ("Clear Room")) {
			genScript.ClearRoom ();
		}
	}
}
