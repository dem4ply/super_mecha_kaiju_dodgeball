using UnityEngine;
using System.Collections;
using controller;
using controller.animator;
using chibi_base;

namespace controller {
	namespace controllers {
		public abstract class Controller_base : Chibi_behaviour {

			#region variables protected
			[System.NonSerialized]
			public controller.motor.Motor_base _motor;
			#endregion

			#region propiedades publicas
			public abstract bool is_running {
				set;
			}

			/// <summary>
			/// modifca el vector de moviento del personaje
			/// </summary>
			public abstract Vector3 direction_vector{
				set;
			}

			public abstract Vector3 desire_direction{
				set;
			}

			public abstract Vector3 velocity_vector{
				get;
			}

			public abstract float max_speed{
				get;
			}
			#endregion

			#region funciones publicas
			public abstract void jump();

			public abstract void stop_jump();

			public abstract void attack();
			public abstract void stop_attack();

			public abstract void left_bumper();
			public abstract void right_bumper();

			public virtual void look_at( Transform target )
			{
				_motor.look_at( target );
			}
			public virtual void look_at( Vector3 target )
			{
				_motor.look_at( target );
			}
			#endregion

			#region funciones protegidas
			protected override void _init_cache() {
				_init_cache_motor();
			}

			protected virtual void _init_cache_motor() {
				_motor = GetComponent<motor.Motor_base>();
			}
			#endregion
		}
	}
}
