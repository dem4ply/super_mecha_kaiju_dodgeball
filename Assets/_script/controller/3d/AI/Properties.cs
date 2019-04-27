using UnityEngine;
using System.Collections;
using controller.animator;
using controller.motor;
using System;
using controller.controllers.ai.tree_d.state;
using controller.controllers.ai.tree_d.stats;
using controller.controllers.ai.tree_d.behavior;
using behavior.tree_d;

namespace controller
{
	namespace controllers
	{
		namespace ai
		{
			namespace tree_d
			{
				namespace data
				{
					[Serializable]
					public class Properties
					{
						public float angle_x, angle_z;
						public int index;
						public float period;

						public float sum_delta_period;
					}
				}
			}
		}
	}
}
