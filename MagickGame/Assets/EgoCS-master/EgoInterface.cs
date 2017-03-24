using UnityEngine;
using Components.AI.System;
using Components.Action.System;
using Components.Attachment.System;
using Components.Steering.System;

public class EgoInterface : MonoBehaviour {
	static EgoInterface()
	{
		EgoSystems.Add(
			new AttachmentSystem(),
			new ActionSystem(),
			new MovementSystem(), 
			new BehaviorTreeSystem()
		);
	}

    void Start()
    {
    	EgoSystems.Start();
	}
	
	void Update()
	{
		EgoSystems.Update();
	}
	
	void FixedUpdate()
	{
		EgoSystems.FixedUpdate();
	}
}
