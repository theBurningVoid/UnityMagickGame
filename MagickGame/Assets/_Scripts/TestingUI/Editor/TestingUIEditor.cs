using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(TestingUIScript))]
public class TestingUIEditor : Editor {

	public override void OnInspectorGUI (){
		DrawDefaultInspector ();
		TestingUIScript UIScript = (TestingUIScript)target;

		if (GUILayout.Button ("Empty")) {
			UIScript.placingMode = TestingUIScript.TilePlacingMode.Empty;
		}
		if (GUILayout.Button ("Floor")) {
			UIScript.placingMode = TestingUIScript.TilePlacingMode.Floor;
		}
		if (GUILayout.Button ("Wall")) {
			UIScript.placingMode = TestingUIScript.TilePlacingMode.Wall;
		}
	}
}
