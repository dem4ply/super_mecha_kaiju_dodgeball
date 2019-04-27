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
				[ CreateAssetMenu( menuName="controller/motor/dead/instence" ) ]
				public class Instance: behavior.Beavior
				{
					public GameObject prefab_instance;
					public override void do_dead( Motor_base motor )
					{
						helper.instantiate._(
							prefab_instance, motor.transform.position );
					}
				}
			}
		}
	}
}