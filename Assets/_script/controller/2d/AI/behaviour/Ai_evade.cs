using UnityEngine;

namespace controller
{
	namespace ai
	{
		public class Ai_evade : Ai_steering_behavior
		{
			protected virtual void Update()
			{
				do_evade( target );
			}
		}
	}
}