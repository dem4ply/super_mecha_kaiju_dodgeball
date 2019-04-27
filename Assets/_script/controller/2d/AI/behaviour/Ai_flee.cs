using UnityEngine;

namespace controller
{
	namespace ai
	{
		public class Ai_flee : Ai_steering_behavior
		{
			protected virtual void Update()
			{
				do_flee( target );
			}
		}
	}
}