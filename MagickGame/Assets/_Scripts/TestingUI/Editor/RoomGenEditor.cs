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

		if (GUILayout.Button ("Generate Room")) {
			genScript.GenerateRoom ();
		}
		if (GUILayout.Button ("Clear Room")) {
			genScript.ClearRoom ();
		}

		if (GUILayout.Button ("Save Copy as prefab")) {
			prefab = PrefabUtility.CreatePrefab ("Assets/_Prefabs/Resources/Rooms/" + 
				RoomGenScript.getPrefabResourcesPath(wingType) + wingType.ToString() + 
				genScript.saveAsName + ".prefab", genScript.gameObject);

			DestroyImmediate (prefab.GetComponent<RoomGenScript> (), true);
		}
	}
}