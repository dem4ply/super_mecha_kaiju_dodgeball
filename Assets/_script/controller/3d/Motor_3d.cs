using UnityEngine;
using System.Collections;
using controller;
using chibi_base;
using System;
using System.Collections.Generic;
using weapon.weapon;

namespace controller {
	namespace motor {
		[ RequireComponent( typeof( Rigidbody ) ) ]
		public class Motor_3d : Motor_base {
			#region variables publicas
			#endregion

			#region variables protegidas
			protected Rigidbody _rigidbody;
			protected manager.Collision manager_collisions;
			protected Weapon_base[] weapons;
			#endregion

			#region propiedades publicas

			public override Vector3 velocity_vector {
				get {
					return _rigidbody.velocity;
				}
			}
			#endregion

			#region funciones publicas
			public override void attack()
			{
				throw new NotImplementedException();
			}

			public override void jump()
			{
				throw new NotImplementedException();
			}

			public override void stop_attack()
			{
				throw new NotImplementedException();
			}

			public override void stop_jump()
			{
				throw new NotImplementedException();
			}

			public override void update_animator()
			{
				throw new NotImplementedException();
			}

			public override void update_motion()
			{
				throw new NotImplementedException();
			}
			#endregion

			/// <summary>
			/// inicializa el chache del script
			/// </summary>
			protected override void _init_cache() {
				base._init_cache();
				_rigidbody = GetComponent<Rigidbody>();
				manager_collisions = new manager.Collision();
				_find_my_weapons();
			}

			protected void _find_my_weapons()
			{
				weapons = GetComponentsInChildren<Weapon_base>();
				_set_owner_to_weapons();
			}

			protected virtual void _set_owner_to_weapons()
			{
				foreach ( var weapon in weapons )
					weapon.owner = my_rol;
			}
		}
	}
}