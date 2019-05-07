using System.Collections.Generic;
using UnityEngine;
using chibi.controller.weapon.gun.bullet;

namespace chibi.controller.npc
{
	public class Dodger_controller : Controller_npc
	{
		public chibi.rol_sheet.Rol_sheet rol;
		public SMKD.weapon.gun.Dodger_gun gun;

		public Transform ball_position;

		public chibi.radar.Radar_box catch_radar;
		public chibi.radar.Radar_box dodge_radar;

		public float dodge_time = 1f;
		protected float dodge_delta = 0f;

		public GameObject damage_reciver;
		public bool is_dodging = false;
		public bool has_the_ball = false;

		public Collider ball_collision;

		public damage.motor.HP_motor_old hp_motor;
		public float death_time = 1f;
		public float _delta_death_time = 0f;

		public float counter_time = 2f;
		public float _delta_counter_time = 0f;


		public Animator animator;

		public override Vector3 desire_direction
		{
			get {
				return base.desire_direction;
			}

			set {
				if ( value.magnitude < 0.2 )
					_desire_direction = transform.forward;
				else
					_desire_direction = value;

				var direction = transform.position + _desire_direction;
				gun.transform.LookAt( ( gun.transform.position + _desire_direction ) );
				//base.desire_direction = value;
			}
		}

		#region funciones de controller
		public override void action( string name, string e )
		{
			if ( !hp_motor.is_dead )
			{
				//base.action( name, e );
				switch ( name )
				{
					case chibi.joystick.actions.fire_1:
						switch ( e )
						{
							case chibi.joystick.events.down:
								shot();
								break;
						}
						break;
					case chibi.joystick.actions.fire_2:
						switch ( e )
						{
							case chibi.joystick.events.down:
								dodge();
								break;
						}
						break;
				}
			}
		}
		#endregion

		public List< Controller_bullet > shot()
		{
			if ( has_the_ball )
			{
				damage_reciver.SetActive( true );
				var bullet = gun.shot();
				has_the_ball = false;
				_delta_counter_time = 0f;

				var bullet_motor = ( chibi.motor.weapons.gun.bullet.Bullet_bounce_motor )bullet.motor;
					
				bullet_motor.last_shotter = this;
				bullet_motor.current_live_time = 0f;

				return new List<Controller_bullet>() { bullet };

			}
			return null;
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
			damage_reciver.SetActive( false );
			var d = transform_ball.GetComponentInChildren<damage.Damage>();
			var bullet_controller = transform_ball.GetComponent<
				chibi.controller.weapon.gun.bullet.Controller_bullet>();

			bullet_controller.desire_direction = Vector3.zero;
			gun.bullet = bullet_controller;
			transform_ball.position = ball_position.position;
			has_the_ball = true;
			_delta_counter_time = 0f;
			d.reset();

		}

		public virtual void dodge_ball( Transform transform_ball )
		{
			is_dodging = true;
			damage_reciver.SetActive( false );
			var col1 = GetComponent<BoxCollider>();
			ball_collision = transform_ball.GetComponent<SphereCollider>();
			Physics.IgnoreCollision( col1, ball_collision, true );
		}

		public void Update()
		{
			if ( !hp_motor.is_dead && is_dodging )
			{
				dodge_delta += Time.deltaTime;
				if ( dodge_delta > dodge_time )
				{
					dodge_delta = 0f;
					damage_reciver.SetActive( true );
					var col1 = GetComponent<BoxCollider>();
					Physics.IgnoreCollision( col1, ball_collision, false  );
					is_dodging = false;
				}
			}

			if ( hp_motor.is_dead )
			{
				_delta_death_time += Time.deltaTime;
				if ( _delta_death_time > death_time )
					foreach ( var c in GetComponents<Collider>() )
					{
						c.enabled = false;
					}
			}

			if ( has_the_ball )
			{
				_delta_counter_time += Time.deltaTime;
				if ( _delta_counter_time > counter_time )
				{
					shot();
				}
			}

			animator.SetBool( "is_dodge", is_dodging );
			animator.SetBool( "is_dead", hp_motor.is_dead );
			animator.SetBool( "has_the_ball", has_the_ball );
			Debug.Log( desire_direction, gameObject ); 
			animator.SetFloat( "horizontal", desire_direction.x );
			animator.SetFloat( "vertical", desire_direction.z );
		}

		protected override void _init_cache()
		{
			base._init_cache();
			rol = GetComponent< chibi.rol_sheet.Rol_sheet >();
			if ( !rol )
				Debug.LogError( string.Format(
					"[doger_controller] no encontro un 'Rol_sheet' en {0}",
					helper.game_object.name.full( this ) ), this.gameObject );

			hp_motor = GetComponent< damage.motor.HP_motor_old >();
			if ( !hp_motor)
				Debug.LogError( string.Format(
					"[doger_controller] no encontro un 'hp_motor' en {0}",
					helper.game_object.name.full( this ) ), this.gameObject );

			catch_radar = new radar.Radar_box( catch_radar );
			dodge_radar = new radar.Radar_box( dodge_radar );
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
