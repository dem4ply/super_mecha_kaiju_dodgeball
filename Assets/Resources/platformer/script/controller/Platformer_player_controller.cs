using UnityEngine;
using chibi.controller.npc;
using System.Collections.Generic;
using platformer.controller.platform;

namespace platformer.controller.player
{
	public class Platformer_player_controller : chibi.controller.Controller
	{
		public Controller_npc player;
		public Spawn_platform_radial platform_blender;
		public chibi.pomodoro.Pomodoro_obj jump_buffer_time =
			new chibi.pomodoro.Pomodoro_obj( 0.25f );

		protected Dictionary<string, string> buffer_actions;
		protected Vector3 buffer_desire_direction;

		public override Vector3 desire_direction
		{
			get {
				return player.desire_direction;
			}
			set {
				if ( buffer_jump )
				{
					buffer_direction( value );
				}
				else
				{
					player.desire_direction = value;
				}
			}
		}

		public override float speed
		{
			get {
				return player.speed;
			}
			set {
				if ( value >= 1f )
					player.speed = player.max_speed;
				else
					player.speed = 0f;
			}
		}

		public virtual bool buffer_jump
		{
			get {
				return player.motor_side_scroll.is_walled
					&& player.motor_side_scroll.is_not_grounded;
			}
		}

		public virtual void run_buffer_action()
		{
			foreach ( var b in buffer_actions )
				action( b.Key, b.Value, true );
			player.desire_direction = buffer_desire_direction;

			clean_buffer();
		}

		protected virtual void clean_buffer()
		{
			buffer_desire_direction = Vector3.zero;
			buffer_actions.Clear();
		}

		private void Update()
		{
			if ( buffer_jump )
			{
				if ( jump_buffer_time.tick() )
				{
					run_buffer_action();
					jump_buffer_time.is_enable = false;
					jump_buffer_time.reset();
				}
			}
			else
			{
				jump_buffer_time.reset();
				jump_buffer_time.is_enable = false;
			}
		}

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !player )
				debug.error( "no esta asignado el player controller" );
			if ( !platform_blender )
				debug.error( "no esta asignado el platform bender" );
			buffer_actions = new Dictionary<string, string>();
		}

		public virtual void action( string name, string e, bool buffer )
		{
			switch ( name )
			{
				case "fire1":
					switch ( e )
					{
						case chibi.joystick.events.down:
							break;
						case chibi.joystick.events.up:
							break;
					}
					break;
				case "jump":
					switch ( e )
					{
						case chibi.joystick.events.down:
							player.jump();
							break;
						case chibi.joystick.events.up:
							player.stop_jump();
							break;
					}
					break;
			}
		}

		public override void action( string name, string e )
		{
			base.action( name, e );
			switch ( name )
			{
				case "fire1":
					action( name, e, true );
					break;
				case "jump":
					if ( buffer_jump )
						buffer_action( name, e );
					else
						action( name, e, true );
					break;
				case "p1__bumper__left":
				case "p1__bumper__right":
				case "p1__trigger__left":
				case "p1__trigger__right":
					switch ( e )
					{
						case chibi.joystick.events.down:
							platform_blender.spawn( 0 );
							break;
					}
					break;
			}
		}

		public virtual void buffer_action( string name, string e )
		{
			if ( !jump_buffer_time.is_enable )
			{
				jump_buffer_time.reset();
				jump_buffer_time.is_enable = true;
			}
			buffer_actions[ name ] = e;
		}

		public virtual void buffer_direction( Vector3 desire_direction )
		{
			if ( !jump_buffer_time.is_enable )
			{
				jump_buffer_time.reset();
				jump_buffer_time.is_enable = true;
			}
			buffer_desire_direction = desire_direction;
		}

		public override void direction( string name, Vector3 direction )
		{
			base.direction( name, direction );
			switch ( name )
			{
				case "p1__aim":
					platform_blender.desire_direction = direction;
					break;
			}
		}
	}
}
