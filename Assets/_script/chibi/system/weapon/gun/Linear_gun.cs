using UnityEngine;
using Unity.Entities;
using chibi.motor;

namespace chibi.systems.weapon.gun
{
	public class Linear_gun : Gun
	{
#pragma warning disable CS0108 // El miembro oculta el miembro heredado.
		protected struct Group
#pragma warning restore CS0108 // El miembro oculta el miembro heredado.
		{
			public chibi.weapon.gun.Linear_gun gun;
		}

		protected override void OnUpdate()
		{
			float delta_time = Time.deltaTime;
			foreach ( var entity in GetEntities<Group>() )
			{
				if ( entity.gun.automatic_shot )
					do_automatic_shot( delta_time, entity.gun );
			}
		}
	}
}
