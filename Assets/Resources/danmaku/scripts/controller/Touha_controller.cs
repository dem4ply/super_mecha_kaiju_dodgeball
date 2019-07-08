using System.Collections.Generic;
using UnityEngine;
using chibi.controller.weapon.gun.bullet;
using chibi.radar;

namespace danmaku.controller.npc
{
	public class Touha_controller : chibi.controller.npc.Controller_npc
	{
		public chibi.rol_sheet.Rol_sheet rol;

		protected override void _init_cache()
		{
			base._init_cache();
			rol = GetComponent< chibi.rol_sheet.Rol_sheet >();
			if ( !rol )
				debug.error( "no encontro un 'Rol_sheet'" );
		}

		protected override void _dispose_cache()
		{
			base._dispose_cache();
		}
	}
}
