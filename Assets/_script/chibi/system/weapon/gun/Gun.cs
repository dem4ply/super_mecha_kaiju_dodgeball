using UnityEngine;
using Unity.Entities;

namespace chibi.systems.weapon.gun
{
	public class Gun : ComponentSystem
	{
		protected struct Group
		{
			public chibi.weapon.gun.Gun gun;
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

		protected virtual void do_automatic_shot(
			float delta_time, chibi.weapon.gun.Gun gun )
		{
			gun.last_automatic_shot += delta_time;
			if ( gun.last_automatic_shot > gun.rate_fire )
			{
				gun.last_automatic_shot -= gun.rate_fire;
				gun.shot();
			}
		}
	}
}
