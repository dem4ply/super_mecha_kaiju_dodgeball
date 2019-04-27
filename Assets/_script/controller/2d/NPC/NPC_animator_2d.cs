using UnityEngine;
using System.Collections;
using System;

namespace controller {
	namespace animator {
		public class NPC_animator_2d : animator.Animator_base
		{
			protected Vector2 _move_vector = Vector2.zero;
			protected float _speed = 0f;

			public const string VERTICAL = "vertical";
			public const string HORIZONTAL = "horizontal";
			public const string SPEED = "speed";

			public virtual Vector2 direction_vector {
				set {
					if ( value.magnitude > 0 )
					{
						_move_vector = value;
						animator.SetFloat( HORIZONTAL, _move_vector.x );
						animator.SetFloat( VERTICAL, _move_vector.y );
					}
				}
			}

			public virtual float speed {
				set {
					_speed = value;
					animator.SetFloat( SPEED, _speed );
				}
			}
		}
	}
}