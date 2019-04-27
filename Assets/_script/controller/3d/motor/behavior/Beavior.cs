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
				public abstract class Beavior : chibi_base.Chibi_object
				{
					public abstract void do_dead( Motor_base motor );
				}
			}
		}
	}
}