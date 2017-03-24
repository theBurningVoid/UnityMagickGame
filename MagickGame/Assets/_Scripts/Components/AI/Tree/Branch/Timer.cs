using Components.Behavior_Tree;

namespace Components.AI.Tree.Branch {
	public class Timer : Delay {
		//After x time, if continuous run every y sec, else run
		public float rate;

		public Timer(BranchNode child, float delay, float rate = -1) : base(child, delay) {
			this.rate = rate;
		}

		public override State Act(EgoComponent root) {
			//InvokeRepeating("Act", delayAmt, rate);
			return State.RUNNING;
		}

		/*protected State Act() {
			return child.Act(this);
		}*/
	}
}