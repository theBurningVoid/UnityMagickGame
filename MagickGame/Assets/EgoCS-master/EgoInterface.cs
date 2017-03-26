using UnityEngine;
using Systems;

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
