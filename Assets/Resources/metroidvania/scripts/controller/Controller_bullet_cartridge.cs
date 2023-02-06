using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using weapon.ammo;
using chibi.pomodoro;
using metroidvania.motor.weapons.gun.bullet;

namespace metroidvania.controller.weapons.gun.bullet
{
	public class Controller_bullet_cartridge : chibi.controller.weapon.gun.bullet.Controller_bullet
	{
		public Bullet_motor_item _motor_item;

		public metroidvania.inventory.item.Cartridge cartridge
		{
			get {
				return _motor_item.cartridge;
			}
			set {
				_motor_item.cartridge = value;
			}
		}

		protected override void _init_cache()
		{
			base._init_cache();
			_motor_item = motor as Bullet_motor_item;
			if ( !_motor_item )
				debug.error( "el motor que tiene el control no es un Bullet_motor_item" );
		}

		public override void recycle()
		{
			_motor_item.recycle();
		}
	}
}
