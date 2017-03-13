using UnityEngine;
using System.Collections;

public class Hitscan : BranchNode {
	public override State Act (BranchNode parent)
	{
		RaycastHit2D clicked = Physics2D.Raycast (transform.position, transform.right);
		Debug.DrawRay (transform.position, transform.right, Color.red, 100, false);
		return State.SUCCESS;
	}
}
