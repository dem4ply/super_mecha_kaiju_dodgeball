using UnityEngine;
using Unity.Entities;
using chibi.motor.weapons.gun.bullet;

namespace chibi.systems.weapon.gun.turrent
{
	public class Turrent : ComponentSystem
	{
		struct group
		{
			public chibi.motor.weapons.gun.turrent.Turrent motor;
			public Rigidbody rigidbody;
		}

		protected override void OnUpdate()
		{
			foreach ( var entity in GetEntities<group>() )
			{
				var motor = entity.motor;
				float angle = Vector3.SignedAngle(
					motor.original_direction, motor.desire_direction,
					motor.rotation_vector );
				float max_angle = motor.max_rotation_angle / 2;
				angle = Mathf.Clamp( angle, -max_angle, max_angle );
				Quaternion desire_rotation;
				if ( angle == 0 )
				{
					desire_rotation = motor.original_rotation;
				}
				else
				{
					desire_rotation = Quaternion.AngleAxis( angle, motor.rotation_vector );
					desire_rotation = desire_rotation * motor.original_rotation;
				}
				/*
				Debug.Log( string.Format(
					"[system.motor.turrent]{0} :: {1} :: {2} :: {3}",
					angle, motor.original_direction, motor.desire_direction,
					desire_rotation.eulerAngles ) );
				*/
				//entity.rigidbody.rotation = desire_rotation;
				entity.rigidbody.MoveRotation( desire_rotation );
			}
		}
	}
}
