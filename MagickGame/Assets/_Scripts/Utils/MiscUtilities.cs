using UnityEngine;
using System.Collections;

public class MiscUtilities {
	public static void DestroyAllChildren(Transform trans)
	{
		for (int i = 0; i < trans.childCount; i++) {
			GameObject.Destroy (trans.GetChild(i).gameObject);
			//Debug.Log ("deleted tile");
		}
	}

	public static void DestroyImmediateAllChildren(Transform trans)
	{
		//Debug.Log ("Child Count: " + trans.childCount);
		while(trans.childCount > 0) {
			GameObject.DestroyImmediate (trans.GetChild(0).gameObject);
			//because we are immediately destroying the object (this is for edit mode not play mode) we have to stick with the 0 index and just keeping destroying until childCount = 0
			//Debug.Log ("deleted tile");
		}
	}
}
