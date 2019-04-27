using UnityEngine;
using System.Collections;
using controller.animator;
using controller.motor;
using controller.controllers;
using chibi_base;

namespace controller {
	namespace joystick {
		public class Joystick : Chibi_behaviour {

			#region public vars
			public string key_map = "player 1";
			public controller.controllers.Controller_base controller;

			public Vector2 axis_mouse = Vector2.zero;
			public Vector2 axis_esdf = Vector2.zero;
			public Vector2 mouse_position = Vector2.zero;
			public float mouse_wheel = 0f;

			public bool run_key = false;
			public bool jump_key = false;
			public bool jump_key_release = false;

			public float dead_zone_esdf_axis = 0.01f;
			public float dead_zone_mouse_axis = 0.01f;
			public float dead_zone_mouse_wheel = 0.01f;
			#endregion

			#region public properties
			public bool is_pass_deadzone_esdf_axis {
				get;
				protected set;
			}
			public bool is_pass_deadzone_mouse_axis {
				get;
				protected set;
			}
			public bool is_pass_deadzone_mouse_wheel {
				get;
				protected set;
			}
			#endregion

			#region public functions
			public void update_all_axis() {
				_get_axis_esdf();
				_get_axis_mouse();
				_get_mouse_pos();
			}

			public void update_all_buttons() {
				_get_keys_running();
				_get_keys_jump();
				_get_key_jump_is_release();
			}
			#endregion

			#region funciones protegdas
			protected void Update() {
				update_all_axis();
				update_all_buttons();
				// si pasa la zona muerta el stick entonces se mueve y cambia la direcion
				if ( is_pass_deadzone_esdf_axis ) {
					controller.direction_vector = axis_esdf;
				}
				else
					controller.direction_vector = Vector2.zero;
				controller.is_running = run_key;
				if ( jump_key )
					controller.jump();
				else
					controller.stop_jump();

				if ( _fire_key_down( 1 ) )
					controller.attack();
				if ( _fire_key_up( 1 ) )
					controller.stop_attack();

				if ( _left_bumper_key_down() )
					controller.left_bumper();

				if ( _right_bumper_key_down() )
					controller.right_bumper();

				_draw_debug();
			}

			/// <summary>
			/// actualiza el eje de movimiento
			/// </summary>
			protected void _get_axis_esdf() {
				axis_esdf = helper.joystick.axis_left;
				is_pass_deadzone_esdf_axis = helper.joystick.pass_dead_zone(
					axis_esdf.magnitude, dead_zone_esdf_axis );
			}

			/// <summary>
			/// revisa si se preciono el boton para correr
			/// </summary>
			protected void _get_keys_running() {
				run_key = Input.GetButton( "run" );
			}

			/// <summary>
			/// revisa si se preciono el boton para saltar
			/// </summary>
			protected void _get_keys_jump() {
				jump_key = Input.GetButton( "jump" );
			}

			/// <summary>
			/// revisa si se dejo de precionar el boton de salto
			/// </summary>
			protected void _get_key_jump_is_release() {
				jump_key_release = Input.GetButtonUp( "jump" );
			}

			/// <summary>
			/// revisa si el boton de fire se preciono, no es un auto fire
			/// </summary>
			/// <param name="fire_number">numero de boton de fire</param>
			/// <returns></returns>
			protected bool _fire_key_down( int fire_number )
			{
				string fire_key = string.Format( "fire_{0}", fire_number );
				return Input.GetButtonDown( fire_key );
			}

			protected bool _fire_key_up( int fire_number )
			{
				string fire_key = string.Format( "fire_{0}", fire_number );
				return Input.GetButtonUp( fire_key );
			}

			protected bool _left_bumper_key_down()
			{
				return Input.GetButtonDown( "left_bumper" );
			}

			protected bool _right_bumper_key_down()
			{
				return Input.GetButtonDown( "right_bumper" );
			}

			/// <summary>
			/// actualiza el eje de movimiento del mouse
			/// </summary>
			protected void _get_axis_mouse() {
				axis_mouse.x = helper.mouse.axis_x;
				axis_mouse.y = helper.mouse.axis_y;
				mouse_wheel = helper.mouse.wheel;
				is_pass_deadzone_mouse_axis = helper.joystick.pass_dead_zone( axis_mouse.magnitude, dead_zone_mouse_axis );
				is_pass_deadzone_mouse_wheel = helper.joystick.pass_dead_zone( mouse_wheel, dead_zone_mouse_wheel );
			}

			/// <summary>
			/// actualiza la posicion del mouse
			/// </summary>
			protected void _get_mouse_pos() {
				mouse_position = Input.mousePosition;
			}

			/// <summary>
			/// inicializa el chache del script
			/// </summary>
			protected override void _init_cache() {
				_init_cache_controller();
			}

			/// <summary>
			/// inicia el cache del controller
			/// </summary>
			protected virtual void _init_cache_controller() {
				if ( controller == null )
					controller = GetComponent<Controller_base>();
			}

			/// <summary>
			/// dibuga el debug
			/// </summary>
			protected virtual void _draw_debug() {
				debug.draw.arrow( axis_esdf );
			}
			#endregion
		}
	}
}
