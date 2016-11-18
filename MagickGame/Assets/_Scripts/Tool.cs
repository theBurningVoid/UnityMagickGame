using UnityEngine;
using System.Collections;

public interface Tool {
	
	// Called when equipped, and with null entity when unequipped
	// Entity reference must be stored to access for future use
	void EquippedBy(GameObject entity);
		
	// Called when activated by equipping entity
	// Assumes that use must be deactivated before activated again and vice versa
	void ToggleUse(int id = 0);
}
