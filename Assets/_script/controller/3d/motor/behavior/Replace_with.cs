using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace controller
{
	namespace motor
	{
		namespace dead
		{
			namespace behavior
			{
				[ CreateAssetMenu( menuName="controller/motor/dead/replace_with" ) ]
				public class Replace_with : behavior.Beavior
				{
					public GameObject prefab_replaceer;
					public override void do_dead( Motor_base motor )
					{
						helper.instantiate._(
							prefab_replaceer, motor.transform.position );
						Destroy( motor.gameObject );
					}
				}
			}
		}
	}
}