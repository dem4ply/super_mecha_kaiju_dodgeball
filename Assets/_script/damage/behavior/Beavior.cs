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

			public virtual chibi.motor.Motor get_motor( Damage damage )
			{
				throw new System.NotImplementedException();
			}
		}
	}
}