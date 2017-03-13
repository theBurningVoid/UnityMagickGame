using UnityEngine;
using System.Collections;

public class Delay : BranchNode
{
	protected float delayAmt;
	public Delay(float sec) {
		this.delayAmt = sec;
	}

	public override State Act (BranchNode parent) {
		new WaitForSeconds (delayAmt);
		return child.Act(this);
	}
}

