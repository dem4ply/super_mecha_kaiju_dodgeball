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

		#region funciones de controller
		#endregion

		#region controlles de torreta
		public List< Controller_bullet > shot()
		{
			throw new System.NotImplementedException();
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
