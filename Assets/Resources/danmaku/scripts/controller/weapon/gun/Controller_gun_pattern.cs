using System.Collections.Generic;
using chibi.damage;
using UnityEngine;
using chibi.controller.weapon.gun.bullet;
using chibi.controller.weapon.gun;
using chibi.weapon.gun;

namespace danmaku.controller.weapon.gun
{
	public class Controller_gun_pattern : Controller_gun
	{
		protected chibi.rol_sheet.Rol_sheet _owner;
		public List< Gun > guns;

		public List< Controller_gun > controllers_guns;

		public chibi.rol_sheet.Rol_sheet owner
		{
			get {
				return _owner;
			}
			set {
				_owner = value;
				update_owner();
			}
		}

		protected override void _init_cache()
		{
			base._init_cache();
			guns = new List<Gun>( transform.GetComponentsInChildren<Gun>() );
			controllers_guns = new List<Controller_gun>(
					transform.GetComponentsInChildren<Controller_gun>() );
			update_owner();
		}

		public override List<Controller_bullet> shot()
		{
			List<Controller_bullet> bullets = new List<Controller_bullet>();
			foreach( var controller_gun in controllers_guns )
			{
				debug.info( controller_gun.name );
				controller_gun.shot();
			}
			foreach ( var gun in guns )
			{
				//bullets.Add( gun.shot() );
			}
			return bullets;
		}

		public override void start_automatic_shot()
		{
			debug.info( "start" );
			foreach( var gun in guns )
			{
				gun.automatic_shot = true;
			}
		}

		public override void stop_automatic_shot()
		{
			debug.info( "stop" );
			foreach( var gun in guns )
			{
				gun.automatic_shot = false;
			}
		}

		protected void update_owner( )
		{
			foreach ( var gun in guns )
			{
				gun.owner = owner;
			}
		}
	}
}
