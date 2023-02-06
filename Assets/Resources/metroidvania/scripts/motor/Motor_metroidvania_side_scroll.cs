using UnityEngine;
using System;
using chibi.manager.collision;
using System.Collections.Generic;

namespace metroidvania.motor
{
	public class Motor_metroidvania_side_scroll : chibi.motor.npc.Motor_side_scroll
	{
		public bool want_to_sit
		{
			get {
				return desire_direction.y < 0;
			}
		}

		protected override void calculate_horizontal_velocity(
			ref Vector3 velocity_vector, float desire_speed,
			float max_speed, float time_to_reach_target,
			Vector3 desire_direction, ref float time_smooth )
		{
			// no se mueve mientras esta sentado
			if ( want_to_sit )
			{
				velocity_vector.z = 0f;
			}
			else
				base.calculate_horizontal_velocity(
					ref velocity_vector, desire_speed,
					max_speed, time_to_reach_target,
					desire_direction, ref time_smooth );
		}
	}
}
