using UnityEngine;
using System.Collections.Generic;


namespace controller
{
	namespace controllers
	{
		namespace ai
		{
			namespace tree_d
			{
				namespace stats
				{
					[CreateAssetMenu( menuName = "controller/ai/stat/timer" )]
					public class Timer : Stat
					{
						public float period = 1f;
						protected float _delta_period;

						public float delta_period
						{
							get {
								return 1 / period;
							}
						}
					}
				}
			}
		}
	}
}
