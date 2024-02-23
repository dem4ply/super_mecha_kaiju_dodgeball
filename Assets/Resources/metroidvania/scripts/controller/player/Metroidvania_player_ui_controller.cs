using UnityEngine;
using chibi.controller.npc;
using System.Collections.Generic;
using platformer.controller.platform;
using UnityEngine.InputSystem;
using metroidvania.controller.npc;
using helper;

namespace metroidvania.controller.player
{
	public class Metroidvania_player_ui_controller : Metroidvania_player_controller
	{
		public metroidvania.grid.Grid_ui grid_ui;

		public Transform debug_shit;

		protected Vector2 _mouse_axis;

		public override Vector2 mouse_position
		{
			get {
				return _mouse_axis;
			}
			set {
				_mouse_axis = value;
			}
		}

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
				case "fire":
					mouse_position_to_cell( this.mouse_position );
					break;
				default:
					debug_action( name, e );
					break;
			}
		}

		protected void Update()
		{
		}

		protected Vector2 mouse_position_to_cell( Vector2 mouse_position )
		{
			Vector2 cell_position = grid_ui.grid.get_x_y_from_ui( mouse_position );
			return cell_position;
		}
	}
}