using UnityEngine;
using System.Collections;

public abstract class Item : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
