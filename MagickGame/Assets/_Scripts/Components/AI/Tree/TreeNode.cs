using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;

namespace Components.AI.Tree {
	public abstract class TreeNode {
		public abstract State Act(EgoComponent root);
	}
	public enum State {
		SUCCESS, FAIL, RUNNING
	}
}
