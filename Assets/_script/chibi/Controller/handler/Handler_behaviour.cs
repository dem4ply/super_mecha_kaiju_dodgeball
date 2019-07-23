using System.Collections.Generic;
using UnityEngine;

namespace chibi.controller.handler
{
	public class Handler_behaviour: Chibi_behaviour
	{
		public List<Handler> handlers = new List<Handler>();
		public bool is_global = true;

		private void OnTriggerEnter( Collider other )
		{
			var controller = other.transform.GetComponent< Controller >();
			if ( !controller )
			{
				controller = other.GetComponentInParent< Controller >();
			}
			if ( controller && ( is_global ) )
			{
				foreach ( var handler in handlers )
				{
					debug.info( "afectando alfgo" );
					handler.action( controller );
				}
			}
		}

		public bool is_in_affected_controllers( Controller controller )
		{
			return false;
		}
	}
}
