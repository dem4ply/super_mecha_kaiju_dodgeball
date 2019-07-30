using UnityEngine;
using weapon.ammo;
using chibi.pomodoro;
using System;
using chibi.motor.weapons.gun.bullet;

namespace chibi.motor.weapons.gun.bullet
{
	[Serializable]
	public class Bullet_step
	{
		public float life_span = 1f;
		protected float current_life_span = 0f;

		[Header( "start step variables" )]
		public float rotate_angle_on_start = 0f;

		[Header( "update step variables" )]
		public AnimationCurve speed_over_life_span;

		public virtual void start( Bullet_motor motor )
		{
			var transform = motor.transform;
			var rotation_to_current_direction =
				Quaternion.Euler( motor.desire_direction );
			var rotation_to_add_angle = Quaternion.Euler( 0, rotate_angle_on_start, 0 );
			motor.desire_direction =
				( rotation_to_current_direction * rotation_to_add_angle )
				* motor.desire_direction;
		}

		public virtual void update( Bullet_motor motor )
		{
			float time = current_life_span / life_span;
			motor.desire_speed =
				speed_over_life_span.Evaluate( time ) * motor.max_speed;
		}

		public bool tick( float time )
		{
			current_life_span += time;
			return current_life_span > life_span;
		}
	}
}
