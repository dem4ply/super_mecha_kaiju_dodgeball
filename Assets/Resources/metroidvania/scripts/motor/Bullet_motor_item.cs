using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using weapon.ammo;
using chibi.pomodoro;

namespace metroidvania.motor.weapons.gun.bullet
{
	public class Bullet_motor_item : chibi.motor.weapons.gun.bullet.Bullet_motor
	{
		public metroidvania.inventory.item.Cartridge cartridge;

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !cartridge )
			{
				//debug.error( "no se asigno el cartridge donde se reciclaria el projectil" );
			}
		}

		public override void recycle()
		{
			if ( cartridge )
				cartridge.push( this );
			else
			{
				debug.error( "se intento de reciclar pero no tiene cartridge asignado" );
			}
		}
	}
}
