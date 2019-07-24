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
			var controller = other.transform.GetComponent< Controller_motor >();
			if ( !controller )
			{
				controller = other.GetComponentInParent< Controller_motor >();
			}
			if ( controller && ( is_global ) )
			{
				foreach ( var handler in handlers )
				{
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
