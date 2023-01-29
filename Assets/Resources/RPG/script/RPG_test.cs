using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;
using chibi.rol_sheet.motor;

namespace rpg.manager
{
	public class RPG_test: chibi.Chibi_behaviour
	{
		public GameObject player, enemy;
		public rpg.motor.RPG_battle_motor_test player_motor, enemy_motor;
		public rpg.ui.RPG_description_battle description_battle;

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !player )
			{
				debug.error( "no se asigno el player" );
			}
			if ( !player_motor )
			{
				debug.info( "buscanod player motor" );
				player_motor = player.GetComponentInChildren<rpg.motor.RPG_battle_motor_test>();
			}
			if ( !player_motor )
			{
				debug.error( "no se encontro el rpg_battle_motor en {0}", player );
			}
			if ( !enemy )
			{
				debug.error( "n ose asigno el enemy" );
			}
			if ( !enemy_motor )
			{
				debug.info( "buscanod enemy motor" );
				enemy_motor = enemy.GetComponentInChildren<rpg.motor.RPG_battle_motor_test>();
			}
			if ( !enemy_motor )
			{
				debug.error( "no se encontro el rpg_battle_motor en {0}", enemy );
			}

			if ( !description_battle )
				debug.error( "no se asigno el descriptor de batalla" );
		}

		public void on_attack()
		{
			this.debug.info( "ataco" );
			var player_damage = player_motor.get_attack_damage();
			string attack_description = player_motor.get_damage_description();
			enemy_motor.take_damage( player_damage );
			description_battle.text = attack_description;

			if ( enemy_motor.is_dead )
			{
				description_battle.text = enemy_motor.get_dead_description();
			}
		}

		public void on_defend()
		{
			this.debug.info( "defendio" );
		}

		public void on_run()
		{
			this.debug.info( "corrio" );
		}

	}
}
