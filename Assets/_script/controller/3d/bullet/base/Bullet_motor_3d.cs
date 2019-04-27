using UnityEngine;
using System.Collections;
using controller.animator;
using controller.motor;
using System;

namespace controller
{
	namespace motor
	{
		public class Bullet_motor_3d : Motor_3d
		{
			protected float velocity_smooth_x, velocity_smooth_y;
			protected float velocity_smooth_z;
			public float acceleration_time = 0;
			public weapon.ammo.Ammo ammo;

			#region funciones de movimiento
			public override void update_motion() {
				Vector3 velocity_vector = helper.clone._( _rigidbody.velocity );

				_proccess_velocity( ref velocity_vector );
				debug.draw.arrow( direction_vector, Color.magenta );
				debug.draw.arrow( velocity_vector, Color.yellow );
				_rigidbody.velocity = velocity_vector;
			}

			protected virtual void _proccess_velocity( ref Vector3 velocity )
			{
				Vector3 smooth_vector;
				Vector3 desire_speed_vector;
				desire_speed_vector = helper.vector3.normalize_speed(
					direction_vector, max_speed );

				if ( acceleration_time == 0 )
					smooth_vector = helper.vector3.smooth_damp(
						velocity, desire_speed_vector, acceleration_time,
						ref velocity_smooth_x, ref velocity_smooth_y,
						ref velocity_smooth_z );
				else
					smooth_vector = desire_speed_vector;

				helper.vector3.set( ref velocity, smooth_vector );
			}
			#endregion

			public override void update_animator()
			{
			}

			/*
			public override void died()
			{
				base.died();
				if ( ammo != null )
				{
					var controller = GetComponent<
						controllers.Bullet_controller_3d>();
					if ( controller )
						singleton.object_pool.Ammo_pool.instance.push( controller );
					else
						Destroy( gameObject );
				}
				else
					Destroy( gameObject );
			}
			*/

			protected override void _init_cache()
			{
				base._init_cache();
				_rigidbody.useGravity = false;
			}
		}

	}
}
