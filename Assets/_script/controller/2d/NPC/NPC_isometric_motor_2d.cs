using UnityEngine;
using System.Collections;
using controller.animator;
using controller.motor;
using System;

namespace controller
{
	namespace motor
	{
		public class NPC_isometric_motor_2d : Motor_2d
		{
			public float acceleration_time_in_ground = 0.1f;
			protected float horizontal_velocity_smooth, vertical_velocity_smooth;
			protected Vector2 atack_direciont = Vector2.zero;

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
				Vector2 velocity_vector = new Vector2(
					_rigidbody.velocity.x, _rigidbody.velocity.y );
				if ( not_is_atacking )
				{
					if( direction_vector.magnitude > 0.1 )
						atack_direciont = direction_vector.normalized;

					_proccess_ground_velocity( ref velocity_vector );
				}
				else
				{
					_proccess_ground_velocity_when_attack( ref velocity_vector );
				}
				debug.draw.arrow( direction_vector, Color.magenta );
				_rigidbody.velocity = velocity_vector;
				debug.draw.arrow( velocity_vector, Color.yellow );
			}

			protected virtual void _proccess_ground_velocity(
				ref Vector2 velocity_vector  )
			{
				Vector2 desire_speed_vector;
				// si es true se esta moviendo a toda velocidad en diagonal
				if ( direction_vector.magnitude > 1 )
					desire_speed_vector = direction_vector.normalized * max_speed;
				else
					desire_speed_vector = direction_vector * max_speed;

				if ( is_running )
					desire_speed_vector *= runner_multiply;

				// suavizado de la velocidad horizontal
				float final_horizontal_velocity = Mathf.SmoothDamp(
					velocity_vector.x, desire_speed_vector.x,
					ref horizontal_velocity_smooth, acceleration_time_in_ground );

				float final_vertical_velocity = Mathf.SmoothDamp(
					velocity_vector.y, desire_speed_vector.y,
					ref vertical_velocity_smooth, acceleration_time_in_ground );

				velocity_vector.x = final_horizontal_velocity;
				velocity_vector.y = final_vertical_velocity;
			}

			protected virtual void _proccess_ground_velocity_when_attack(
				ref Vector2 velocity_vector )
			{
				Vector2 desire_speed_vector = Vector2.zero;

				// suavizado de la velocidad horizontal
				float final_horizontal_velocity = Mathf.SmoothDamp(
					velocity_vector.x, desire_speed_vector.x,
					ref horizontal_velocity_smooth, acceleration_time_in_ground );

				float final_vertical_velocity = Mathf.SmoothDamp(
					velocity_vector.y, desire_speed_vector.y,
					ref vertical_velocity_smooth, acceleration_time_in_ground );

				velocity_vector.x = final_horizontal_velocity;
				velocity_vector.y = final_vertical_velocity;
			}

			#endregion

			#region funciones de animacion
			public override void update_animator() {
				var isometric_animator = _animator as NPC_isometric_animator_2d;
				if ( is_atacking )
				{
					isometric_animator.direction_vector = atack_direciont;
					isometric_animator.speed = 0;
				}
				else
				{
					isometric_animator.direction_vector = direction_vector;
					if ( direction_vector.magnitude > 0 )
						isometric_animator.speed = !is_running ? 0.3f : 0.8f;
					else
						isometric_animator.speed = 0;

				}
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
				Debug.Log( "atacando motor" );
				is_atacking = true;
				var isometric_animator = _animator as NPC_isometric_animator_2d;
				if ( is_atacking )
					isometric_animator.is_attacking = true;

			}

			public override void stop_attack()
			{
				Debug.Log( "deteniendo ataque en el motor" );
				is_atacking = false;
			}

			public virtual void attack_ended()
			{
				stop_attack();
			}

		}

	}
}
