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
			update_owner();
		}

		public override List<Controller_bullet> shot()
		{
			List<Controller_bullet> bullets = new List<Controller_bullet>();
			foreach ( var gun in guns )
			{
				bullets.Add( gun.shot() );
			}
			return bullets;
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
