using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(RoomGenScript))]
public class RoomGenEditor : Editor {

	GameObject prefab;

	public override void OnInspectorGUI (){
		DrawDefaultInspector ();
		RoomGenScript genScript = (RoomGenScript)target;

		RoomGenScript.WingType wingType = genScript.wingType;

		if (GUILayout.Button ("Generate Blank Room")) {
			genScript.GenerateBlankRoom ();
		}
		if (GUILayout.Button ("Clear Room")) {
			genScript.ClearRoom ();
		}

		if (GUILayout.Button ("Save Copy as prefab")) {
			if (genScript.transform.childCount > 0) {
				string path = "Assets/_Prefabs/Resources/Rooms/" +
				             RoomGenScript.getPrefabResourcesPath (wingType) + wingType.ToString () +
				             genScript.saveAsName + ".prefab";

				prefab = PrefabUtility.CreatePrefab (path, genScript.transform.GetChild (0).gameObject);
			}
		}
	}
}