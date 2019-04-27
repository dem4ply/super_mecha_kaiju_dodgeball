using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Transforms;
using System.Collections;
using chibi.controller;
using chibi.motor.npc;

namespace chibi.systems.controller
{
	public class Motor_movement_isometric : ComponentSystem
	{

		struct group
		{
			public Motor_isometric motor;
			public Rigidbody rigidbody;
		}

		protected override void OnUpdate()
		{
			float delta_time = Time.deltaTime;
			foreach ( var entity in GetEntities<group>() )
			{
				Vector3 desire_velocity = entity.motor.desire_velocity;
				entity.rigidbody.velocity = new Vector3(
					desire_velocity.x, entity.rigidbody.velocity.y,
					desire_velocity.z );
				entity.motor.current_speed = desire_velocity;
			}
		}
	}
}
