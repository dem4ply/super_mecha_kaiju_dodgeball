using UnityEngine;
using System.Collections.Generic;
using controller;
using chibi.controller.actuator;
using Unity.Entities;
using System;
using System.Linq;

namespace chibi.controller.steering
{
	public class Steering : Chibi_behaviour
	{
		public Transform target;
		public Controller_motor controller;
		public List<behavior.Behavior> behaviors;
		public List<Steering_properties> behaviors_properties;

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !behaviors.Any() )
			{
				Debug.LogWarning( string.Format(
					"el steering controller de '{0}' no tiene behavior",
					helper.game_object.name.full( this )
				) );
			}
			behaviors_properties = new List<Steering_properties>( behaviors.Count );

			for ( int i = 0; i < behaviors.Count; ++i )
			{
				Steering_properties propertie = new Steering_properties();
				behaviors[ i ].prepare_properties( this, propertie );
				behaviors_properties.Add( propertie );
			}
		}

		public IEnumerable<(behavior.Behavior, Steering_properties)> zip()
		{
			return behaviors.Zip(
				behaviors_properties,
				( behavior, properties ) => ( behavior, properties ) );
		}
	}
}
