using UnityEngine;
using System.Collections;
using System;

namespace controller {
	namespace animator {
		public class animator_3d : animator.Animator_base
		{
			protected Vector3 _move_vector = Vector3.zero;
			protected float _speed = 0f;

			public const string VERTICAL = "vertical";
			public const string HORIZONTAL = "horizontal";
			public const string SPEED = "speed";

			public virtual Vector3 direction_vector {
				set {
					if ( value.magnitude > 0 )
					{
						_move_vector = value;
						animator.SetFloat( HORIZONTAL, _move_vector.x );
						animator.SetFloat( VERTICAL, _move_vector.z );
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