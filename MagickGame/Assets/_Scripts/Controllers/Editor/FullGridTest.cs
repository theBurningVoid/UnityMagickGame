using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FullGridWingContoller))]
public class FullGridTest : Editor {


	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();

		FullGridWingContoller controller = (FullGridWingContoller)target;

		if (GUILayout.Button ("Generate")) {
			controller.Generate ();
		}

		if (GUILayout.Button ("ClearImmediateAllChildren")) {
			controller.ClearImmediateAllChildren ();
		}
	}
}
