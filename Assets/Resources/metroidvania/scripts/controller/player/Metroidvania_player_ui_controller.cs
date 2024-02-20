using UnityEngine;
using chibi.controller.npc;
using System.Collections.Generic;
using platformer.controller.platform;
using UnityEngine.InputSystem;
using metroidvania.controller.npc;

namespace metroidvania.controller.player
{
	public class Metroidvania_player_ui_controller : Metroidvania_player_controller
	{
		public metroidvania.grid.Grid_ui grid_ui;

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !grid_ui )
				debug.error( "no esta asignado el grid ui" );
		}

		public override void action( string name, string e )
		{
			base.action( name, e );
			switch ( name )
			{
				default:
					debug_action( name, e );
					break;
			}
		}
	}
}
