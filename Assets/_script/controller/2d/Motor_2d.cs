using UnityEngine;
using System.Collections;
using controller;
using chibi_base;
using System;
using System.Collections.Generic;

namespace controller {
	namespace motor {
		public class Motor_2d : Motor_base
		{
			#region variables publicas
			#endregion

			#region variables protegidas
			protected Rigidbody2D _rigidbody;
			protected manager.Collision_2d manager_collisions;

			public override Vector3 velocity_vector
			{
				get {
					return _rigidbody.velocity;
				}
			}

			public override void attack()
			{
				throw new NotImplementedException();
			}
			#endregion

			#region propiedades publicas
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
				_rigidbody = GetComponent<Rigidbody2D>();
				manager_collisions = new manager.Collision_2d();
				_rigidbody.gravityScale = 0f;
			}
		}
	}
}
