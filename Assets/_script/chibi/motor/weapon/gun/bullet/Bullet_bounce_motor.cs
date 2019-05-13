using UnityEngine;

namespace SMKD.motor.weapons.gun.bullet
{
	public class Bullet_bounce_motor : chibi.motor.Motor
	{
		public SMKD.controller.npc.Dodger_controller last_shotter;
		public float live_time = 10f;
		public float current_live_time = 30f;
		public int max_bounce = 10;

		public int current_amount_of_bounce = 0;

		private void OnCollisionEnter( Collision collision )
		{
			var new_direction = Vector3.Reflect( desire_direction, collision.contacts[ 0 ].normal );
			desire_direction = new_direction;

			current_amount_of_bounce += 1;
			if ( current_amount_of_bounce > max_bounce )
			{
				get_last_shooter().grab_ball( transform );
			}
			current_live_time = 0f;
		}

		private void Update()
		{
			var _last_shooter = get_last_shooter();
			if ( _last_shooter )
			{
				current_live_time += Time.deltaTime;

				if ( current_live_time > live_time )
				{
					_last_shooter.grab_ball( transform );
					current_live_time = 0f;
				}
			}
 		}

		public SMKD.controller.npc.Dodger_controller get_last_shooter()
		{
			if ( last_shotter && !last_shotter.hp_motor.is_dead )
				return last_shotter;
			var shotters = FindObjectsOfType<SMKD.controller.npc.Dodger_controller>();
			foreach ( var shotter in shotters )
			{
				if ( shotter.hp_motor.is_dead )
					return shotter;
			}
			return last_shotter;
		}
	}
}
