using UnityEngine;
using System.Collections.Generic;
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
				behaviors[ i ].prepare_properties( this, propertie, target );
				behaviors_properties.Add( propertie );
			}
		}

		public IEnumerable<(behavior.Behavior, Steering_properties)> zip()
		{
			return behaviors.Zip(
				behaviors_properties,
				( behavior, properties ) => (behavior, properties) );
		}

		private void Update()
		{
			Vector3 desire_direction = Vector3.zero;
			float desire_speed = 1f;

			foreach ( var (behavior, properties) in zip() )
			{
				properties.time += Time.deltaTime;
				var behavior_direction = behavior.desire_direction(
					this, target, properties );

				if ( behavior_direction == Vector3.zero )
					continue;
				behavior_direction *= behavior.weight;
				//entity.sterring.debug.draw.arrow( behavior_direction, Color.black );
				desire_direction += behavior_direction;
			}
			debug.draw.arrow( desire_direction, Color.black );
			controller.desire_direction = desire_direction;

			desire_speed = controller.motor.max_speed * desire_speed;
			controller.speed = desire_speed;
		}
	}
}
