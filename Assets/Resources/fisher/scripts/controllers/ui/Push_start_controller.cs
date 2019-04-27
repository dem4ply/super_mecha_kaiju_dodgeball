using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace fisher.controller
{
	public class Push_start_controller : chibi.controller.Controller
	{
		public override void action( string name, string e )
		{
			base.action( name, e );
			switch ( name )
			{
				case "fire1":
					switch ( e )
					{
						case "down":
							SceneManager.LoadScene( "Resources/fisher/scene/game_mode_1" );
							break;
					}
					break;
			}
		}
	}
}
