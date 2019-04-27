using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using weapon.stat;
using weapon.ammo;

using chibi.controller.weapon.gun.bullet;


namespace chibi.weapon.gun
{
	public abstract class Gun : Weapon
	{
		public Gun_stat stat;
		public Ammo ammo;

		public bool automatic_shot = false;

		[HideInInspector] public float last_automatic_shot = 0f;

		public Vector3 direction_shot
		{
			get { return transform.forward.normalized; }
		}

		public float rate_fire
		{
			get {
				return 1 / stat.rate_fire;
			}
		}

		public abstract Controller_bullet shot();

		public override void attack()
		{
			shot();
		}

		protected override void _init_cache()
		{
			base._init_cache();
			if ( ammo == null )
			{
				ammo = load_default_ammo() as Ammo;
			}
			if ( stat == null )
			{
				stat = load_default_stat() as Gun_stat;
			}
		}

		protected virtual chibi_base.Chibi_object load_default_ammo()
		{
			return Ammo.CreateInstance<Ammo>().find_default<Ammo>();
		}

		protected virtual chibi_base.Chibi_object load_default_stat()
		{
			return Gun_stat.CreateInstance<Gun_stat>()
				.find_default<Gun_stat>();
		}

		protected void OnDrawGizmos()
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawWireSphere( transform.position, 0.2f );
			Gizmos.color = Color.red;
			helper.draw.arrow.gizmo( transform.position, direction_shot );
		}
	}
}
