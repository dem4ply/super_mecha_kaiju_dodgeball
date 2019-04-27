using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace damage
{
	namespace behavior
	{
		[ CreateAssetMenu( menuName="weapon/behavior/one_hit_destroy" ) ]
		public class One_hit_destroy : behavior.Beavior
		{
			public override void taken_damange( Damage damage )
			{
				Debug.Log(
					string.Format( "One hit destroy en {0}", damage.gameObject ) );
				var motor = get_motor( damage );
				if ( motor == null )
					MonoBehaviour.Destroy( damage.gameObject );
				else
					motor.died();
			}
		}
	}
}