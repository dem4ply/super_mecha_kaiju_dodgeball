using UnityEngine;
using System.Collections.Generic;

namespace spawner
{
	namespace invoker
	{
		public class Timer : Invoker
		{
			public float delta_time = 1f;
			public int amount_of_spawn = 0;

			protected float _sigma_time = 0f;
			protected int _amount_of_spawns = 0;

			protected void Update()
			{
				_sigma_time += Time.deltaTime;
				if ( _sigma_time >= delta_time )
				{
					target.spawn();
					_sigma_time -= delta_time;
					if (
						amount_of_spawn > 0
						&& ++_amount_of_spawns >= amount_of_spawn )
					{
						enabled = false;
					}

				}
			}
		}
	}
}