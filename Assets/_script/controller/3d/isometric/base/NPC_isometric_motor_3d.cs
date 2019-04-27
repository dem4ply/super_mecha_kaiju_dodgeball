using UnityEngine;
using System.Collections;
using controller.animator;
using controller.motor;
using System;

namespace controller
{
	namespace motor
	{
		public class NPC_isometric_motor_3d : Motor_3d
		{
			public float acceleration_time_in_ground = 0.1f;
			protected float horizontal_velocity_smooth, vertical_velocity_smooth;
			protected Vector3 atack_direciont = Vector3.zero;

			public override Vector3 direction_vector
			{
				protected get {
					return base.direction_vector;
				}

				set {
					base.direction_vector = value;
				}
			}

			public virtual bool is_atacking
			{
				get;
				protected set;
			}

			public virtual bool not_is_atacking
			{
				get
				{
					return !is_atacking;
				}
			}

			#region funciones de movimiento
			public override void update_motion() {
				debug.draw.arrow( direction_vector, Color.magenta );
				Vector3 velocity_vector = new Vector3(
					_rigidbody.velocity.x, _rigidbody.velocity.y,
					_rigidbody.velocity.z );

				_proccess_ground_velocity( ref velocity_vector );
				debug.draw.arrow( velocity_vector, Color.yellow );
				_rigidbody.velocity = velocity_vector;
			}

			protected virtual void _proccess_ground_velocity(
				ref Vector3 velocity  )
			{
				Vector3 desire_speed_vector;
				// si es true se esta moviendo a toda velocidad en diagonal
				if ( direction_vector.magnitude > 1 )
					desire_speed_vector = direction_vector.normalized * max_speed;
				else
					desire_speed_vector = direction_vector * max_speed;

				if ( is_running )
					desire_speed_vector *= runner_multiply;

				// suavizado de la velocidad horizontal
				float final_horizontal_velocity = Mathf.SmoothDamp(
					velocity.x, desire_speed_vector.x,
					ref horizontal_velocity_smooth, acceleration_time_in_ground );

				float final_vertical_velocity = Mathf.SmoothDamp(
					velocity.z, desire_speed_vector.z,
					ref vertical_velocity_smooth, acceleration_time_in_ground );

				velocity.x = final_horizontal_velocity;
				velocity.z = final_vertical_velocity;
			}
			#endregion

			#region funciones de animacion
			public override void update_animator()
			{
			}
			#endregion

			public override void jump()
			{
			}
			public override void stop_jump()
			{
			}

			public override void attack()
			{
				Debug.Log( "atacando motor isometrico" );
				is_atacking = true;
			}

			public override void stop_attack()
			{
				Debug.Log( "deteniendo ataque en el motor isometrico" );
				is_atacking = false;
			}

			public virtual void attack_ended()
			{
				stop_attack();
			}

		}

	}
}
