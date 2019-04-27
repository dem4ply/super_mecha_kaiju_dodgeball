using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace damage
{
	namespace behavior
	{
		public abstract class Beavior : chibi_base.Chibi_object
		{
			public abstract void taken_damange( Damage damage );

			public virtual controller.motor.Motor_base get_motor( Damage damage )
			{
				var motor = damage.GetComponent<controller.motor.Motor_base>();
				return motor;
			}
		}
	}
}