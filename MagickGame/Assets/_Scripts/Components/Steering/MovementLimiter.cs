using UnityEngine;

namespace Components.Steering {
	[DisallowMultipleComponent]
	class MovementLimiter: MonoBehaviour {
		public float MaxLinearSpeed = 10, MaxAngularSpeed = 10, MaxLinearAcceleration = 10, MaxAngularAcceleration = 10;

		public GameObject Initialize(GameObject entity, float maxLinearSpeed, float maxAngularSpeed, float maxLinearAcceleration, float maxAngularAcceleration) {
			MovementLimiter comp = entity.AddComponent<MovementLimiter>();
			comp.MaxLinearSpeed = maxLinearSpeed;
			comp.MaxAngularSpeed = maxAngularSpeed;
			comp.MaxLinearAcceleration = maxLinearAcceleration;
			comp.MaxAngularAcceleration = maxAngularAcceleration;
			return entity;
		}
	}
}
