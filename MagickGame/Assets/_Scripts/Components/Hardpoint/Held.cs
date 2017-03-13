using UnityEngine;
using System.Collections;
using System;

public class Held : Hardpoint {
	Rigidbody2D item;

	public void Set(Rigidbody2D body){
		if (body != null) {
			Drop ();
			item = body;
			Hardpoint handle = item.GetComponent<Hardpoint> ();
			body.transform.SetParent (transform);
			if (handle != null) {
				body.transform.localRotation = Quaternion.identity;
				body.transform.localPosition = getHardpoint ();
			}
			body.isKinematic = true;
			body.simulated = false;
		}
	}

	public void Drop() {
		if (item != null) {
			item.transform.SetParent (null);
			item.isKinematic = false;
			item.simulated = true;
			item = null;
		}
	}

	public void Use() {
		if (item != null) {
			BranchNode action = item.gameObject.GetComponent<BranchNode> ();
			if (action != null) {
				action.Act (null);
			}
		}
	}

	public Boolean IsEmpty(){
		return item == null;
	}
}