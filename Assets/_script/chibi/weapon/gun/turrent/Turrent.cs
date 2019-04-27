using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace chibi.motor.weapons.gun.turrent
{
	public class Turrent : Motor
	{
		public Vector3 rotation_vector = Vector3.up;
		public float max_rotation_angle = 180f;

		[HideInInspector] public float current_rotation_angle = 0f;

		public Vector3 original_direction;
		public Quaternion original_rotation;
		public float rotation_times;
		public float current_angle = 0f;

		protected override void _init_cache()
		{
			base._init_cache();
			original_direction = transform.forward;
			original_rotation = transform.rotation;
		}
	}
}