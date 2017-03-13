using System.Collections.Generic;
using UnityEngine;

/*
 * The node of behavior trees. The top-level node with no parent is the trunk, and nodes without children are leaves.
 */
public abstract class BranchNode : MonoBehaviour {
	// A priority-ordered list of the children branches of this branch.
	public BranchNode child;

	// This is called by a parent branch, which sends itself as an argument and can react to the returned State.
	public abstract State Act (BranchNode parent);
}

public enum State {
	SUCCESS, FAIL, RUNNING
}