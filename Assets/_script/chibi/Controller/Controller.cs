using UnityEngine;
using System.Collections;
using controller;
using chibi.controller.actuator;
using Unity.Entities;
using System;

namespace chibi.controller
{
	public class Controller : Chibi_behaviour
	{
		protected Vector3 _desire_direction;
		protected float _speed;

		public motor.Motor motor;

		public bool pasive_motor;

		public virtual Vector3 desire_direction
		{
			get {
				return _desire_direction;
			}

			set {
				_desire_direction = value;
				motor.desire_direction = value;
				// debug.draw.arrow( value, Color.black );
			}
		}

		public virtual float speed {
			get {
				return _speed;
			}

			set {
				_speed = value;
				motor.desire_speed = value;
			}
		}

		public virtual void action( string name, string e )
		{
			Debug.Log( string.Format(
				"[{0}] action '{1}' with the event '{2}'",
				helper.game_object.name.full( this ), name, e
			) );
		}

		protected override void _init_cache()
		{
			base._init_cache();
			load_motors();
		}

		protected virtual void load_motors()
		{
			motor = GetComponent<motor.Motor>();
			if ( !motor )
			{
				Debug.LogError( string.Format(
					"no se encontro un motor en el object {0}" +
					"se agrega un motor",
					helper.game_object.name.full( this ) ),
					gameObject );
				motor = gameObject.AddComponent<motor.Motor>();
			}
			if ( pasive_motor )
			{
				var rigidbody = GetComponent<Rigidbody>();
				rigidbody.useGravity = false;
			}
		}

	}
}
