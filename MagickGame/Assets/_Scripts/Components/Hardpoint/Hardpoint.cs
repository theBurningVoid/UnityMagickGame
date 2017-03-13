using UnityEngine;
using System.Collections;
using System.ComponentModel.Design;

public class Hardpoint : MonoBehaviour {
	Vector2 hardpoint;

	public void setHardpoint(Vector2 hardpoint) {
		this.hardpoint = hardpoint;
	}

	public Vector2 getHardpoint() {
		return hardpoint;
	}
}