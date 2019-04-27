using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using chibi.controller.weapon.gun.bullet;
using rol_sheet;

namespace chibi.controller.npc
{
	public class Dodger_controller : Controller_npc
	{
		public chibi.rol_sheet.Rol_sheet rol;
		public SMKD.weapon.gun.Dodger_gun gun;

		public Transform ball_position;

		public chibi.radar.Radar_box catch_radar;
		public chibi.radar.Radar_box dodge_radar;

		public override Vector3 desire_direction
		{
			get {
				return base.desire_direction;
			}

			set {
				if ( value.magnitude < 0.2 )
					_desire_direction = transform.forward;
				else
					_desire_direction = value;

				var direction = transform.position + _desire_direction;
				gun.transform.LookAt( direction );
				//base.desire_direction = value;
			}
		}

		#region funciones de controller
		public override void action( string name, string e )
		{
			base.action( name, e );
			switch ( name )
			{
				case chibi.joystick.actions.fire_1:
					switch ( e )
					{
						case chibi.joystick.events.down:
							shot();
							break;
					}
					break;
				case chibi.joystick.actions.fire_2:
					switch ( e )
					{
						case chibi.joystick.events.down:
							dodge();
							break;
					}
					break;
			}
		}
		#endregion

		public List< Controller_bullet > shot()
		{
			var bullet = gun.shot();
			return new List<Controller_bullet>() { bullet };
			//throw new System.NotImplementedException();
		}

		public void dodge()
		{
			catch_radar.ping();
			if ( catch_radar.hits.Count > 0 )
			{
				Debug.LogError( "fasdjlfkasjdflkj" );
				grab_ball( catch_radar.hits[ 0 ].transform );
				return;
			}

			dodge_radar.ping();
			if ( dodge_radar.hits.Count > 0 )
			{
				Debug.LogError( "fasdjlfkasjdflkj" );
				dodge_ball( catch_radar.hits[0].transform );
				return;
			}
			//throw new System.NotImplementedException();
		}

		public virtual void grab_ball( Transform transform_ball )
		{
			var d = transform_ball.GetComponent<damage.Damage>();
			var bullet_controller = transform_ball.GetComponent<
				chibi.controller.weapon.gun.bullet.Controller_bullet>();
			d.reset();
			bullet_controller.desire_direction = Vector3.zero;
			gun.bullet = bullet_controller;
			transform_ball.position = ball_position.position;
		}

		public virtual void dodge_ball( Transform transform_ball )
		{
		}

		protected override void _init_cache()
		{
			base._init_cache();
			rol = GetComponent< chibi.rol_sheet.Rol_sheet >();
			if ( !rol )
				Debug.LogError( string.Format(
					"[doger_controller] no encontro un 'Rol_sheet' en {0}",
					helper.game_object.name.full( this ) ), this.gameObject );

			catch_radar = new radar.Radar_box( catch_radar );
			dodge_radar = new radar.Radar_box( dodge_radar );
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
