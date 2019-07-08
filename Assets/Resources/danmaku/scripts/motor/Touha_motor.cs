using System.Collections.Generic;
using chibi.controller.weapon.gun.bullet;
using chibi.weapon.gun;
using UnityEngine;
using chibi.pomodoro;

namespace danmaku.motor
{
	public class Touha_motor : chibi.motor.npc.Motor_isometric
	{
		public chibi.damage.motor.HP_engine hp_motor;

		protected override void _init_cache()
		{
			base._init_cache();

			hp_motor = GetComponent< chibi.damage.motor.HP_engine >();
			if ( !hp_motor )
				debug.error( "no se encontro un hp_engine" );

			hp_motor.on_died += on_died;
		}

		protected override void _dispose_cache()
		{
			base._dispose_cache();
			hp_motor.on_died -= on_died;
		}
	}
}