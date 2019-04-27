using UnityEngine;
using System.Collections;
using controller;
using controller.animator;
using chibi_base;
using System;

namespace controller {
	namespace controllers {
		public class Controller_3d : Controller_base
		{

			#region variables protected
			#endregion

			#region propiedades publicas
			public override bool is_running {
				set {
					_motor.is_running = value;
				}
			}

			/// <summary>
			/// modifca el vector de moviento del personaje
			/// </summary>
			public override Vector3 direction_vector{
				set {
					_motor.direction_vector = new Vector3( value.x, 0, value.y );
				}
			}

			public override Vector3 desire_direction
			{
				set {
						_motor.direction_vector = value;
					}
			}

			public override Vector3 velocity_vector{
				get {
					return _motor.velocity_vector;
				}
			}

			public override float max_speed{
				get {
					return _motor.current_max_speed;
				}
			}
			#endregion

			#region funciones publicas
			public override void jump()
			{
				_motor.jump();
			}

			public override void stop_jump()
			{
				_motor.stop_jump();
			}

			public override void attack()
			{
				_motor.attack();
			}

			public override void stop_attack()
			{
				_motor.stop_attack();
			}

			public override void left_bumper()
			{
				throw new NotImplementedException();
			}

			public override void right_bumper()
			{
				throw new NotImplementedException();
			}

			#endregion

			#region funciones protegidas
			#endregion
		}
	}
}
