using UnityEngine;
using chibi.controller.npc;
using System.Collections.Generic;
using platformer.controller.platform;

namespace platformer.controller.wagon
{
	public class Wagon : chibi.controller.Controller
	{
		public chibi.path.Path_behaviour path;
		public chibi.controller.Controller controller;

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !path )
				debug.warning( "no tiene path" );

			if ( !controller )
				debug.warning( "no tiene un controller" );
		}
	}
}
