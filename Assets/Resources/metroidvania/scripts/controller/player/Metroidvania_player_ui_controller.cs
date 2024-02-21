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
				debug.log( "fuck" );
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
			Vector3 mouse_ui_position = new Vector3( mouse_position.x, mouse_position.y, 0 );
			debug.draw.sphere( grid_ui.rect_transform.position + mouse_ui_position, Color.red, 100f );
			float x = mouse_position.x - grid_ui.rect_transform.position.x;
			float y = grid_ui.rect_transform.position.y - mouse_position.y;

			//debug.log( "{0}, {1}, {2} {3}", x, y, mouse_position, grid_ui.rect_transform.position );
		}

		protected Vector2 mouse_position_to_cell( Vector2 mouse_position )
		{

			float x = mouse_position.x - grid_ui.rect_transform.position.x;
			float y = grid_ui.rect_transform.position.y - mouse_position.y;
			Vector3 world_position = new Vector3( x, y, 0 );

			Vector2 cell_position = grid_ui.grid.get_x_y_from_ui( mouse_position );
			debug.log( cell_position );

			return cell_position;
		}
	}
}