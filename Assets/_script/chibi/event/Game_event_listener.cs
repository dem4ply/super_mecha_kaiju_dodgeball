using chibi.rol_sheet;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;


namespace chibi.events
{
	public class Game_event_listener : Chibi_behaviour
	{
		public Game_event _event;
		public UnityEvent response;

		private void OnEnable()
		{
			_event.register( this );
		}

		private void OnDisable()
		{
			_event.unregister( this );
		}

		public void on_event_raised()
		{
		}
	}
}
