using UnityEngine;
using System.Collections;
using controller;
using chibi_base;
using System;
using System.Collections.Generic;

namespace controller {
	namespace motor {
		public abstract class Motor_base : Chibi_behaviour {
			#region variables publicas
			public float max_speed = 10f;
			public float runner_multiply = 2.0f;

			public dead.behavior.Beavior dead_behavior;
			[HideInInspector] public rol_sheet.Rol_sheet my_rol;
			#endregion

			#region variables protegidas
			protected Transform _transform;
			protected Vector3 _move_vector;
			protected Vector3 _direction_vector = Vector3.zero;
			protected bool _is_dead = false;


			[System.NonSerialized]
			protected animator.Animator_base _animator;
			#endregion

			#region propiedades publicas
			public virtual Vector3 direction_vector {
				set {
					_direction_vector = value;
				}
				protected get {
					return _direction_vector;
				}
			}

			public abstract void jump();
			public abstract void stop_jump();

			public virtual bool is_running {
				get; set;
			}

			public virtual bool is_dead
			{
				get {
					return _is_dead;
				}
				protected set {
					_is_dead = value;
				}
			}
			public virtual bool is_not_dead {
				get {
					return !is_dead; }
			}

			public abstract Vector3 velocity_vector
			{
				get;
			}

			public virtual float current_max_speed {
				get {
					if ( is_running )
						return max_speed * runner_multiply;
					return max_speed;
				}
			}
			#endregion

			protected void FixedUpdate() {
			//protected void Update() {
				update_motor();
			}
			/// <summary>
			/// inicializa el chache del script
			/// </summary>
			protected override void _init_cache() {
				_init_cache_animator();
				_find_my_rol();
			}

			protected virtual void _init_cache_animator() {
				_animator = GetComponent<animator.Animator_base>();
			}

			public void update_motor() {
				update_motion();
				update_animator();
				after_update_motor();
			}

			public abstract void update_motion();

			public abstract void update_animator();

			public abstract void attack();

			public abstract void stop_attack();

			public virtual void look_at( Transform target )
			{
				look_at( target.position );
			}
			public virtual void look_at( Vector3 target )
			{
				Vector3 direction = target - transform.position;
				Quaternion rotation = Quaternion.LookRotation( direction );
				transform.rotation = rotation;
			}

			public virtual void died()
			{
				is_dead = true;
				if ( dead_behavior != null )
					dead_behavior.do_dead( this );
				else
					Debug.LogWarning(
						string.Format(
							"el motor {0} no tiene un dead.Behavior", name ) );
			}

			protected void _find_my_rol()
			{
				my_rol = GetComponent<rol_sheet.Rol_sheet>();
				if ( !my_rol )
					Debug.Log( string.Format(
						"[{0}][{1}] no encontro el componente de rol",
						this.GetType(), name ) );
			}

			public virtual void after_update_motor() {
			}
		}
	}
}