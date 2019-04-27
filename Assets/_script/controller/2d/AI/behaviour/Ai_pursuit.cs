using UnityEngine;

namespace controller
{
	namespace ai
	{
		public class Ai_pursuit : Ai_steering_behavior
		{
			protected virtual void Update()
			{
				do_pursuit( target );
			}
		}
	}
}