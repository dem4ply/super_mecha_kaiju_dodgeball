using System.Collections;
using UnityEngine;
using weapon.ammo;
using chibi.pomodoro;

namespace chibi.motor.weapons.gun.bullet
{
	public class Bullet_motor : Motor
	{
		public Ammo ammo;
		public float life_span;
		public bool alway_rotate_to_velocity_direction = true;
		protected IEnumerator __life_span;

		protected override void _init_cache()
		{
			base._init_cache();
			prepare_life_span();
		}

		protected virtual void prepare_life_span()
		{
			__life_span = recicle_when_life_span_end();
			StartCoroutine( __life_span );
		}

		protected virtual IEnumerator recicle_when_life_span_end()
		{
			yield return new WaitForSeconds( life_span );
			recycle();
		}

		public override void recycle()
		{
			ammo.push( this );
		}

		protected override void update_motion()
		{
			base.update_motion();
			if ( alway_rotate_to_velocity_direction )
				if ( desire_direction != Vector3.zero )
					transform.rotation = Quaternion.LookRotation(
						desire_direction, transform.up );
		}
	}
}
