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
			}
		}
		#endregion

		#region controlles de torreta
		public List< Controller_bullet > shot()
		{
			var bullet = gun.shot();
			return new List<Controller_bullet>() { bullet };
			//throw new System.NotImplementedException();
		}
		#endregion

		protected override void _init_cache()
		{
			base._init_cache();
			rol = GetComponent< chibi.rol_sheet.Rol_sheet >();
			if ( !rol )
				Debug.LogError( string.Format(
					"[doger_controller] no encontro un 'Rol_sheet' en {0}",
					helper.game_object.name.full( this ) ), this.gameObject );
		}
	}
}
