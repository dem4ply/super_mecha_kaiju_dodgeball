using UnityEngine;
using chibi.controller.npc;
using System.Collections.Generic;
using platformer.controller.platform;
using UnityEngine.InputSystem;
using metroidvania.controller.npc;

namespace metroidvania.controller.player
{
	public abstract class Metroidvania_player_controller : chibi.controller.Controller
	{
		public Controller_metroidvania_npc player;

		public Camera main_camera;

		abstract public Vector2 mouse_position {
			get;
			set;
		}

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !main_camera )
				main_camera = helper.game_object.camera.maid_camera;
			if ( !main_camera )
				debug.error( "no se asigno la camara al control" );
		}
	}
}
