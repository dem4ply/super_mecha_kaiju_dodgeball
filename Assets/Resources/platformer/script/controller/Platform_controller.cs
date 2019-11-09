using UnityEngine;
using chibi.controller.npc;
using System.Collections.Generic;
using platformer.controller.platform;
using platformer.motor.platform;

namespace platformer.controller.platform
{
	public class Platform_controller : chibi.controller.Controller
	{
		public motor.platform.Platform_motor motor;

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !motor )
				motor = find_child_platforms();
			if ( !motor )
				debug.warning( "no tiene un platform motor" );
		}

		protected virtual Platform_motor find_child_platforms()
		{
			Platform_motor motor = null;

			if ( transform.childCount < 1 )
			{
				debug.warning( "la plataforma no tiene hijos" );
			}
			else
			{
				Transform platform = transform.GetChild( 0 );
				motor = platform.GetComponent< Platform_motor >();
			}
			return motor;
		}
	}
}
