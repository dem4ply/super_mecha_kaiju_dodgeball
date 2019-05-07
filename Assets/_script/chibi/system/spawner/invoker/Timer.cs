using UnityEngine;
using Unity.Entities;

namespace chibi.systems.spawner.invoker
{
	public class Timer : ComponentSystem
	{
		struct group
		{
			public chibi.spawner.invoker.Timer timer;
		}

		protected override void OnUpdate()
		{
			float delta_time = Time.deltaTime;
			foreach ( var entity in GetEntities<group>() )
			{
				var timer = entity.timer;
				timer.time += delta_time;
			}
		}
	}
}