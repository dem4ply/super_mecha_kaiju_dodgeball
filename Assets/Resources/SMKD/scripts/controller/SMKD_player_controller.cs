using System.Collections.Generic;
using UnityEngine;

namespace chibi.controller
{
	public class SMKD_player_controller : Controller
	{

		public List<npc.Dodger_controller> dodgers;
		public override Vector3 desire_direction
		{
			get {
				return base.desire_direction;
			}

			set {
				if ( value.magnitude < 0.2 )
					_desire_direction = transform.forward;
				else
					_desire_direction = value;

				foreach ( var dodger in dodgers )
					dodger.desire_direction = _desire_direction;
			}
		}

		#region funciones de controller
		public override void action( string name, string e )
		{
			base.action( name, e );
			switch ( name )
			{
				case "shot":
					switch ( e )
					{
						case chibi.joystick.events.down:
							shot();
							break;
					}
					break;
				case "catch":
					switch ( e )
					{
						case chibi.joystick.events.down:
							dodge();
							break;
					}
					break;
			}
		}
		#endregion

		public void shot()
		{
			foreach ( var dodger in dodgers )
			{
				dodger.shot();
			}
		}

		public void dodge()
		{
			foreach ( var dodger in dodgers )
				dodger.dodge();
		}
	}
}
