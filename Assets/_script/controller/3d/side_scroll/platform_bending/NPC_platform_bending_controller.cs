using UnityEngine;
using System.Collections;

namespace controller
{
	namespace controllers
	{
		public class NPC_platform_bending_controller
			: NPC_side_scroll_controller_3d
		{
			public motor.platform.Platform_motor_base platform_left;
			public motor.platform.Platform_motor_base platform_right;

			public override void left_bumper()
			{
				summon_left_platform();
			}

			public override void right_bumper()
			{
				summon_right_platform();
			}

			public virtual GameObject summon_left_platform()
			{
				return platform_left.summon();
			}

			public virtual GameObject summon_right_platform()
			{
				return platform_right.summon();
			}
		}
	}
}
