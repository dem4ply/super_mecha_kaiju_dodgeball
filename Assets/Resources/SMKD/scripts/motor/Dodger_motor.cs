﻿using System.Collections.Generic;
using chibi.controller.weapon.gun.bullet;
using chibi.weapon.gun;
using UnityEngine;

namespace SMKD.motor
{
	public class Dodger_motor : chibi.motor.Motor
	{
		public chibi.radar.Radar_box catch_radar;
		public chibi.radar.Radar_box dodge_radar;
		public SMKD.weapon.gun.Dodger_gun gun;

		public bool is_dodging = false;
		public bool has_the_ball = false;

		public float dodge_time = 1f;
		protected float dodge_delta = 0f;

		public GameObject damage_reciver;
		public damage.motor.HP_motor_old hp_motor;

		public float counter_time = 2f;
		public float _delta_counter_time = 0f;

		public SMKD.animator.Animator_dodger animator;

		public bool is_dead
		{
			get {
				return hp_motor.is_dead;
			}
		}

		public override Vector3 desire_direction
		{
			get {
				return base.desire_direction;
			}

			set {
				base.desire_direction = value;
				gun.aim_direction = value;
			}
		}

		public void dodge()
		{
			if ( !is_dodging )
			{
				catch_radar.ping();
				foreach ( var hit in catch_radar.hits )
				{
					if ( hit.transform.GetComponent<Controller_bullet>() )
					{
						grab_ball( hit.transform );
						return;
					}
				}

				dodge_radar.ping();
				foreach ( var hit in dodge_radar.hits )
				{
					Debug.Log( hit.transform.name );
					if ( hit.transform.GetComponent<Controller_bullet>() )
					{
						dodge_ball( hit.transform );
						return;
					}
				}
			}
		}

		public virtual void grab_ball( Transform transform_ball )
		{
			var bullet_controller = transform_ball.GetComponent<
				chibi.controller.weapon.gun.bullet.Controller_bullet>();
			bullet_controller.recycle();
			load_gun();
		}

		public virtual void load_gun()
		{
			gun.load();
			has_the_ball = true;
		}

		public virtual void dodge_ball( Transform transform_ball )
		{
			is_dodging = true;
			damage_reciver.SetActive( false );
			var col1 = GetComponent<BoxCollider>();
			col1.enabled = false;
		}

		public List< Controller_bullet > shot()
		{
			if ( has_the_ball && gun.is_load )
			{
				var bullet = gun.shot();
				has_the_ball = false;
				_delta_counter_time = 0f;

				var bullet_motor = (
					SMKD.motor.weapons.gun.bullet.Bullet_bounce_motor )bullet.motor;
					
				// bullet_motor.last_shotter = this;
				// bullet_motor.current_live_time = 0f;

				return new List<Controller_bullet>() { bullet };

			}
			return null;
		}

		private void Update()
		{
			if ( !is_dead && is_dodging )
			{
				dodge_delta += Time.deltaTime;
				if ( dodge_delta > dodge_time )
				{
					dodge_delta = 0f;
					damage_reciver.SetActive( true );
					var col1 = GetComponent<BoxCollider>();
					col1.enabled = true;
					is_dodging = false;
				}
			}

			animator.is_dodge = is_dodging;
			animator.is_dead = hp_motor.is_dead;
			animator.has_the_ball = has_the_ball;
			animator.direction = desire_direction;
		}

		protected override void FixedUpdate()
		{
			// base.FixedUpdate();
		}

		protected override void _init_cache()
		{
			base._init_cache();

			catch_radar = new chibi.radar.Radar_box( catch_radar );
			dodge_radar = new chibi.radar.Radar_box( dodge_radar );

			hp_motor = GetComponent< damage.motor.HP_motor_old >();
			if ( !hp_motor)
				Debug.LogError( string.Format(
					"[doger_motor] no encontro un 'hp_motor' en {0}",
					helper.game_object.name.full( this ) ), this.gameObject );
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireCube( catch_radar.origin.position, catch_radar.size );

			Gizmos.color = Color.blue;
			Gizmos.DrawWireCube( dodge_radar.origin.position, dodge_radar.size );
		}
	}
}