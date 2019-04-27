using UnityEngine;
using Unity.Entities;
using chibi.motor;
using UnityEngine.Experimental.PlayerLoop;

namespace chibi.systems.motor
{
	[UpdateAfter( typeof( Vertical_jump ) ) ]
	[UpdateAfter( typeof( FixedUpdate ) ) ]
	public class Simple_gravity : ComponentSystem
	{
		struct group
		{
			public chibi.motor.Simple_gravity motor;
			public Rigidbody rigidbody;
		}

		protected override void OnUpdate()
		{
			float delta_time = Time.deltaTime;
			foreach ( var entity in GetEntities<group>() )
			{
				entity.rigidbody.velocity += entity.motor.gravity * delta_time;
			}
		}
	}
}
