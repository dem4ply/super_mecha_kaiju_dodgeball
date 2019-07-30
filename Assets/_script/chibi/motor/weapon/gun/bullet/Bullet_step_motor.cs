using System.Collections.Generic;
using UnityEngine;
using weapon.ammo;
using chibi.pomodoro;

namespace chibi.motor.weapons.gun.bullet
{
	public class Bullet_step_motor : Bullet_motor
	{
		[Header( "step motor" )]
		public int index_step = 0;
		public float current_life_span = 0f;
		public List< Bullet_step > steps;

		protected bool stop_steps = false;

		protected virtual void step()
		{
			debug.warning( index_step.ToString() );
			var step = steps[ index_step ];
			step.update( this );
		}

		protected override void update_motion()
		{
			fixed_update_life_span();
			if ( !stop_steps )
				step();
			base.update_motion();
		}

		protected virtual void fixed_update_life_span()
		{
			if ( stop_steps )
				return;
			var step = steps[ index_step ];
			if ( step.tick( Time.fixedDeltaTime ) )
			{
				if ( ++index_step < steps.Count )
				{
					step = steps[ index_step ];
					step.start( this );
				}
				else
					stop_steps = true;
			}
		}

		public override void reset()
		{
			debug.log( "reset" );
			base.reset();
		}
	}
}
