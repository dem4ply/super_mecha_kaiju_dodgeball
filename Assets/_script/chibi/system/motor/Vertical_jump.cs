using UnityEngine;
using Unity.Entities;
using chibi.motor;
using UnityEngine.Experimental.PlayerLoop;

namespace chibi.systems.motor
{
	[UpdateAfter( typeof( FixedUpdate ) ) ]
	public class Vertical_jump : ComponentSystem
	{
		struct group
		{
			public chibi.motor.Vertical_jump motor;
			public Rigidbody rigidbody;
		}

		protected override void OnUpdate()
		{
			float delta_time = Time.deltaTime;
			foreach ( var entity in GetEntities<group>() )
			{
				if ( entity.motor.want_to_jump && entity.motor.is_grounded )
				{
					entity.rigidbody.velocity = new Vector3(
						entity.rigidbody.velocity.x,
						entity.motor.desire_velocity,
						entity.rigidbody.velocity.z );
					entity.motor.want_to_jump = false;
				}
			}
		}
	}
}
