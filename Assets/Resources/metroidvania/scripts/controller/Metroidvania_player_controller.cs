using UnityEngine;
using chibi.controller.npc;
using System.Collections.Generic;
using platformer.controller.platform;
using UnityEngine.InputSystem;
using metroidvania.controller.npc;

namespace metroidvania.controller.player
{
	public class Metroidvania_player_controller : chibi.controller.Controller
	{
		public Controller_metroidvania_npc player;

		public virtual Vector2 mouse_position
		{
			set {
				player.mouse_position = value;
			}
		}
	}
}
