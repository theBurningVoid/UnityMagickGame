using UnityEngine;
using System.Collections;
using UnityEditor.Animations;

public class Timer : Delay {
	//After x time, if continuous run every y sec, else run
	float rate;

	public Timer(float delay, float rate = -1): base(delay){
		this.rate = rate;
	}

	public override State Act (BranchNode parent) {
		InvokeRepeating ("Act", delayAmt, rate);
		return State.RUNNING;
	}

	protected State Act() {
		return child.Act (this);
	}
}
