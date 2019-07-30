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
			ammo.push( this );
		}

		public override Vector3 desire_direction
		{
			get {
				var desire = base.desire_direction;
				if ( desire.magnitude > 0 )
					return transform.forward;
				return Vector3.zero;
			}

			set {
				base.desire_direction = value;
				if ( value.magnitude > 0 )
					transform.rotation = Quaternion.LookRotation(
						value, transform.up );
			}
		}
	}
}
