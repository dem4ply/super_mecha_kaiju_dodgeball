﻿using UnityEngine;

namespace chibi.motor.npc
{
	public class Motor_side_scroll : Motor
	{
		public override Vector3 desire_direction
		{
			set {
				base.desire_direction = new Vector3( 0, 0, value.z );
			}
		}

		protected override void FixedUpdate()
		{
			ridgetbody.velocity = new Vector3(
				desire_velocity.x, ridgetbody.velocity.y,
				desire_velocity.z );
			current_speed = desire_velocity;
		}
	}
}