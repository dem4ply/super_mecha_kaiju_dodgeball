using chibi.controller.weapon.gun.bullet;
using chibi.weapon.gun;
using UnityEngine;

namespace SMKD.motor
{
	public class Dodger_motor : chibi.motor.Motor
	{
		public chibi.radar.Radar_box catch_radar;
		public chibi.radar.Radar_box dodge_radar;

		public bool is_dodging = false;
		public bool has_the_ball = false;

		public void dodge()
		{
			if ( !is_dodging )
			{
				catch_radar.ping();
				foreach ( var hit in catch_radar.hits )
				{
					if ( hit.transform.GetComponent<Controller_bullet>() )
					{
						grab_ball( hit.transform );
						return;
					}
				}

				dodge_radar.ping();
				foreach ( var hit in dodge_radar.hits )
				{
					if ( hit.transform.GetComponent<Controller_bullet>() )
					{
						dodge_ball( hit.transform );
						return;
					}
				}
			}
		}

		public virtual void grab_ball( Transform transform_ball )
		{
			/*
			damage_reciver.SetActive( false );
			var d = transform_ball.GetComponentInChildren<damage.Damage>();
			var bullet_controller = transform_ball.GetComponent<
				chibi.controller.weapon.gun.bullet.Controller_bullet>();

			bullet_controller.desire_direction = Vector3.zero;
			gun.bullet = bullet_controller;
			has_the_ball = true;
			_delta_counter_time = 0f;
			d.reset();
			*/
			Debug.Log( "grab ball" );
		}

		public virtual void dodge_ball( Transform transform_ball )
		{
			/*
			is_dodging = true;
			damage_reciver.SetActive( false );
			var col1 = GetComponent<BoxCollider>();
			ball_collision = transform_ball.GetComponent<SphereCollider>();
			Physics.IgnoreCollision( col1, ball_collision, true );
			*/
			Debug.Log( "dodge ball" );
		}

		protected override void _init_cache()
		{
			base._init_cache();

			catch_radar = new chibi.radar.Radar_box( catch_radar );
			dodge_radar = new chibi.radar.Radar_box( dodge_radar );
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireCube( catch_radar.origin.position, catch_radar.size );

			Gizmos.color = Color.blue;
			Gizmos.DrawWireCube( dodge_radar.origin.position, dodge_radar.size );
		}
	}
}