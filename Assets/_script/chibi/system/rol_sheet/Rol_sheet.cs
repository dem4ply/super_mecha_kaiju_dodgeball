using UnityEngine;
using Unity.Entities;
using chibi.motor;

namespace chibi.systems.rol_sheet
{
	public class Rol_sheet : ComponentSystem
	{
		struct group
		{
			public chibi.rol_sheet.Rol_sheet rol_sheet;
		}

		protected override void OnUpdate()
		{
			float delta_time = Time.deltaTime;
			foreach ( var entity in GetEntities<group>() )
			{
				var rol_sheet = entity.rol_sheet;
				foreach ( var buff_attacher in rol_sheet.buffos )
				{
					buff_attacher.total_duration += delta_time;
					buff_attacher.delta_sigma += delta_time;
				}
				rol_sheet.clean();
			}
		}
	}
}