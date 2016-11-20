using UnityEngine;
using System.Collections;

public abstract class Tool : MonoBehaviour {
	// Called when equipped, and with null entity when unequipped
	// Entity reference must be stored to access for future use
	public virtual void EquippedBy(GameObject entity) {

	}
		
	// Called when activated by equipping entity
	// Assumes that use must be deactivated before activated again and vice versa
	public abstract void ToggleUse(int id = 0);
}
