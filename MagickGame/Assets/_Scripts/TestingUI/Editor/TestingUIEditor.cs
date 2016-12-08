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

	public void OnSceneGUI()
	{
		TestingUIScript UIScript = (TestingUIScript)target;
		Event current = Event.current;
		int controlID = GUIUtility.GetControlID (GetHashCode (), FocusType.Passive);

		switch (current.type) {//test the event type to be either mouse down, mouse up or a layout event(part of the whole make left clicking an object not select it happen)
		case EventType.MouseDown:
			switch (current.button) {
			case 0:
				UIScript.tileGUIClicked (HandleUtility.GUIPointToWorldRay (current.mousePosition));
				//Debug.Log ("Left mouse button down at " + eventMousePosition.ToString ());
				break;
			case 1://yeah I know 1 should be middle click and 2 right click but unity/maybe c# as i forget which 
				//Debug.Log ("Right mouse button down at " + eventMousePosition.ToString ());
				break;
			case 2:
				//Debug.Log ("Middle mouse button down at " + eventMousePosition.ToString ());
				break;
			}
			current.Use ();
			break;

		case EventType.MouseUp:
			switch (current.button) {
			case 0:
				//Debug.Log ("Left mouse button up at " + eventMousePosition.ToString ());
				break;
			case 1:
				//Debug.Log ("Right mouse button up at " + eventMousePosition.ToString ());
				break;
			case 2:
				//Debug.Log ("Middle mouse button up at " + eventMousePosition.ToString ());
				break;
			}
			current.Use ();
			break;

		case EventType.Layout:
			HandleUtility.AddDefaultControl (controlID);
			break;
		}
	}


}
