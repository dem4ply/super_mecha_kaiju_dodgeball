using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace controller
{
	namespace isometric
	{
		namespace motor
		{
			public class NPC_fly_isometric_motor_3d
				: controller.motor.NPC_isometric_motor_3d
			{

				protected override void _init_cache()
				{
					base._init_cache();
					_rigidbody.useGravity = false;
				}
			}
		}
	}
}