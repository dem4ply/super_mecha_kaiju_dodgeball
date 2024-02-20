﻿using UnityEngine;
using System.Collections.Generic;
using chibi.controller;
using UnityEngine.InputSystem;
using chibi.joystick;
using metroidvania.controller.player;
using UnityEditor;


namespace metroidvania.joystick
{
	public class Joystick_metroidvania: chibi.Chibi_behaviour
	{
		#region public vars
		public string key_map = "player 1";
		public metroidvania.input.Metroidvania control;
		public Metroidvania_player_character_controller controller;
		public Metroidvania_player_ui_controller ui_controller;
		public bool is_selectec_player = true;

		#endregion

		#region protected vars
		protected Vector3 _desire_direction = Vector3.zero;
		protected float _desire_speed = 0f;
		#endregion

		#region public properties
		public Metroidvania_player_controller current_controller
		{
			get{
				if ( is_selectec_player )
					return controller;
				else
					return ui_controller;
			}
		}
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
				// controller.action( "p1__bumper__left", chibi.joystick.events.down );
				current_controller.action( "p1__bumper__left", chibi.joystick.events.down );
		}

		public void on_vertical_spawn( InputAction.CallbackContext context )
		{
			if ( context.started )
				// controller.action( "p1__trigger__right", chibi.joystick.events.down );
				current_controller.action( "p1__trigger__right", chibi.joystick.events.down );
		}

		public void on_jump( InputAction.CallbackContext context )
		{
			if ( context.started )
			{
				// controller.action( "jump", chibi.joystick.events.down );
				current_controller.action( "jump", chibi.joystick.events.down );
			}
			else if ( context.canceled )
			{
				//controller.action( "jump", chibi.joystick.events.up );
				current_controller.action( "jump", chibi.joystick.events.up );
			}
		}

		public void on_fire( InputAction.CallbackContext context )
		{
			if ( context.started )
			{
				//controller.action( "fire", chibi.joystick.events.down );
				current_controller.action( "fire", chibi.joystick.events.down );
			}
			else if ( context.canceled )
			{
				//controller.action( "fire", chibi.joystick.events.up );
				current_controller.action( "fire", chibi.joystick.events.up );
			}
		}

		#region funciones protegdas
		protected void Update()
		{
			// controller.desire_direction = _desire_direction;
			// controller.speed = _desire_speed;

			current_controller.desire_direction = _desire_direction;
			current_controller.speed = _desire_speed;

			//controller.mouse_position = Mouse.current.position.ReadValue();
			//controller.mouse_position = helper.mouse.axis;
			current_controller.mouse_position = helper.mouse.axis;
		}

		/// <summary>
		/// inicializa el chache del script
		/// </summary>
		protected override void _init_cache()
		{
			// no se puede hacer esto ahora porque el control esta separado del joystick
			/*
			if ( controller == null )
				controller = GetComponent<Metroidvania_player_controller>();
			*/
			if ( !controller )
				debug.error( "no se asigno el player controller" );

			if ( !ui_controller )
				debug.error( "no se asigno el player ui controller" );

			control.Enable();
			control.Player.Move.performed += on_move;
			control.Player.Move.canceled += on_move;
			control.Player.Move.started += on_move;

			control.Player.jump.performed += on_jump;
			control.Player.jump.canceled += on_jump;
			control.Player.jump.started += on_jump;

			control.Player.fire1.performed += on_fire;
			control.Player.fire1.canceled += on_fire;
			control.Player.fire1.started += on_fire;
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

			control.Player.fire1.performed -= on_fire;
			control.Player.fire1.canceled -= on_fire;
			control.Player.fire1.started -= on_fire;
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
