using UnityEngine;
using System.Collections.Generic;
using chibi.controller;
using UnityEngine.InputSystem;
using chibi.joystick;
using metroidvania.controller.player;


namespace metroidvania.joystick
{
	public class Joystick_metroidvania: chibi.Chibi_behaviour
	{
		#region public vars
		public string key_map = "player 1";
		public metroidvania.input.Metroidvania control;
		public Metroidvania_player_controller controller;

		#endregion

		#region protected vars
		protected Vector3 _desire_direction = Vector3.zero;
		protected float _desire_speed = 0f;
		#endregion

		#region public properties
		#endregion

		#region public functions
		#endregion

		public void on_move( InputAction.CallbackContext context )
		{
			var vector = context.ReadValue<Vector2>();
			_desire_direction = new Vector3( vector.y, 0, vector.x );
			if ( 0.1f < _desire_direction.magnitude )
				_desire_speed = 1f;
			else
				_desire_speed = 0f;
		}
		public void on_horizontal_spawn( InputAction.CallbackContext context )
		{
			if ( context.started )
				controller.action( "p1__bumper__left", chibi.joystick.events.down );
		}

		public void on_vertical_spawn( InputAction.CallbackContext context )
		{
			if ( context.started )
				controller.action( "p1__trigger__right", chibi.joystick.events.down );
		}

		public void on_jump( InputAction.CallbackContext context )
		{
			if ( context.started )
			{
				controller.action( "jump", chibi.joystick.events.down );
			}
			else if ( context.canceled )
			{
				controller.action( "jump", chibi.joystick.events.up );
			}
		}

		#region funciones protegdas
		protected void Update()
		{
			controller.desire_direction = _desire_direction;
			controller.speed = _desire_speed;

			controller.mouse_position = Mouse.current.position.ReadValue();
		}

		/// <summary>
		/// inicializa el chache del script
		/// </summary>
		protected override void _init_cache()
		{
			if ( controller == null )
				controller = GetComponent<Metroidvania_player_controller>();

			control.Enable();
			control.Player.Move.performed += on_move;
			control.Player.Move.canceled += on_move;
			control.Player.Move.started += on_move;

			control.Player.jump.performed += on_jump;
			control.Player.jump.canceled += on_jump;
			control.Player.jump.started += on_jump;
		}

		protected override void _dispose_cache()
		{
			base._dispose_cache();
			control.Disable();
			control.Player.Move.performed -= on_move;
			control.Player.Move.canceled -= on_move;
			control.Player.Move.started -= on_move;

			control.Player.jump.performed -= on_jump;
			control.Player.jump.canceled -= on_jump;
			control.Player.jump.started -= on_jump;
		}

		protected virtual bool check_action_down( string action )
		{
			return Input.GetButtonDown( action );
		}

		protected virtual bool check_action_up( string action )
		{
			return Input.GetButtonUp( action );
		}
		#endregion

		protected override void Awake()
		{
			base.Awake();
			control = new metroidvania.input.Metroidvania();
		}

	}
}
