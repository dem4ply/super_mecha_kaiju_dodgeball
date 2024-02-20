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

		protected Vector3 mouse_position_to_cell( Vector2 mouse_position )
		{
			var distancia = main_camera.transform.InverseTransformPoint( transform.position );
			Vector3 mouse_3d = new Vector3( mouse_position.x, mouse_position.y, distancia.z );
			Vector3 world_position = main_camera.ScreenToWorldPoint( mouse_3d );

			debug_shit.position = world_position;

			int x, y;
			grid_ui.grid.get_x_y_from_world( world_position, out x, out y );
			debug.log( "x: {0}, {1}", x, y );

			return world_position;
		}
	}
}
