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
				[ CreateAssetMenu( menuName="controller/motor/dead/destroy" ) ]
				public class Destroy : behavior.Beavior
				{
					public override void do_dead( Motor_base motor )
					{
						Destroy( motor.gameObject );
					}
				}
			}
		}
	}
}