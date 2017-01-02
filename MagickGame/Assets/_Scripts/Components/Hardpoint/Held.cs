using UnityEngine;
using System.Collections;
using System;

public class Held : MonoBehaviour {
	Rigidbody2D item;

	public Rigidbody2D Set(Rigidbody2D body){
		Rigidbody2D temp = item;
		item = body;
		item.transform.SetParent (null);
		item.isKinematic = false;
		body.transform.SetParent (transform);
		body.isKinematic = true;
		return temp;
	}

	public void Use(int val = -1) {
		item.SendMessage ("Use", val);
	}

	public Boolean Empty(){
		return item == null;
	}
}
