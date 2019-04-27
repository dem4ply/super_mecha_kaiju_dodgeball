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
				public class AI_controller_gun_3d : AI_controller_3d
				{
					public State weapon_state;

					protected virtual void find_guns()
					{
					}
				}
			}
		}
	}
}
