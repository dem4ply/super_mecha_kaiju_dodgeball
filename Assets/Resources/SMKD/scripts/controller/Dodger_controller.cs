using System.Collections.Generic;
using UnityEngine;
using chibi.controller.weapon.gun.bullet;
using chibi.radar;

namespace SMKD.controller.npc
{
	public class Dodger_controller : chibi.controller.npc.Controller_npc
	{
		public chibi.rol_sheet.Rol_sheet rol;
		public SMKD.tool.Dodger_set dodger_set;

		public damage.motor.HP_motor_old hp_motor;

		public float counter_time = 2f;
		public float _delta_counter_time = 0f;

		public override Vector3 desire_direction
		{
			get {
				return base.desire_direction;
			}

			set {
				if ( value.magnitude < 0.2 )
					base.desire_direction = transform.forward;
				else
					base.desire_direction = value;
			}
		}

		public SMKD.motor.Dodger_motor dodger_motor
		{
			get {
				return motor as SMKD.motor.Dodger_motor;
			}
		}

		#region funciones de controller
		public override void action( string name, string e )
		{
			if ( !hp_motor.is_dead )
			{
				//base.action( name, e );
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
		}
		#endregion

		public List< Controller_bullet > shot()
		{
			return dodger_motor.shot();
		}

		public void dodge()
		{
			dodger_motor.dodge();
		}

		public virtual void grab_ball( Transform transform_ball )
		{
			dodger_motor.grab_ball( transform_ball );
		}

		public virtual void dodge_ball( Transform transform_ball )
		{
			dodger_motor.dodge_ball( transform_ball );
		}

		public void Update()
		{
			if ( dodger_motor.has_the_ball )
			{
				_delta_counter_time += Time.deltaTime;
				if ( _delta_counter_time > counter_time )
				{
					shot();
				}
			}
		}

		protected override void _init_cache()
		{
			base._init_cache();
			rol = GetComponent< chibi.rol_sheet.Rol_sheet >();
			if ( !rol )
				Debug.LogError( string.Format(
					"[doger_controller] no encontro un 'Rol_sheet' en {0}",
					helper.game_object.name.full( this ) ), this.gameObject );

			hp_motor = GetComponent< damage.motor.HP_motor_old >();
			if ( !hp_motor)
				Debug.LogError( string.Format(
					"[doger_controller] no encontro un 'hp_motor' en {0}",
					helper.game_object.name.full( this ) ), this.gameObject );
		}

	}
}
