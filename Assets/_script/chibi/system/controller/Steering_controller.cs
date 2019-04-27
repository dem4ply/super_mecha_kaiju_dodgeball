using UnityEngine;
using Unity.Entities;
using System.Linq;

namespace chibi.systems.controller
{
	public class Steering_controller : ComponentSystem
	{
		struct group
		{
			public chibi.controller.steering.Steering sterring;
		}

		protected override void OnUpdate()
		{
			float delta_time = Time.deltaTime;
			foreach ( var entity in GetEntities<group>() )
			{
				Vector3 desire_direction = Vector3.zero;
				float desire_speed = 1f;
				var controller = entity.sterring.controller;

				foreach ( var ( behavior, properties ) in entity.sterring.zip() )
				{
					properties.time += delta_time;
					var behavior_direction = behavior.desire_direction(
						entity.sterring, entity.sterring.target,
						properties );

					if ( behavior_direction == Vector3.zero )
						continue;
					behavior_direction *= behavior.weight;
					//entity.sterring.debug.draw.arrow( behavior_direction, Color.black );
					desire_direction += behavior_direction;
				}
				entity.sterring.debug.draw.arrow( desire_direction, Color.black );
				controller.desire_direction = desire_direction;

				desire_speed = controller.motor.max_speed * desire_speed;
				controller.speed = desire_speed;
			}
		}
	}
}
