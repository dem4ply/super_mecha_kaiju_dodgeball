using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;
using chibi.rol_sheet.motor;
using chibi.inventory.item.damage;

namespace rpg.motor
{
	public class RPG_battle_motor_test : chibi.rol_sheet.motor.RPG_battle_motor
	{
		public rpg.ui.RPG_status_battle status;
		
		public string character_name
		{
			get {
				return rol_sheet.sheet.person.full_name;
			}
		}

		public bool is_dead
		{
			get {
				return rol_sheet.hp_engine.is_dead;
			}
		}

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !status )
			{
				debug.warning( "no tiene asignado el rpg status battle" );
				status = GetComponent<rpg.ui.RPG_status_battle>();
			}

			if ( !status )
			{
				debug.error( "no se encontro el rpg status battle" );
			}
		}

		protected virtual void prepare_status()
		{
			status.status_name = character_name;
			status.hp_engine = rol_sheet.hp_engine;
			status.hit_points = ( int )rol_sheet.hp_engine.stat.max;
		}

		public virtual void update_hp_status()
		{
			status.hit_points = ( int )rol_sheet.hp_engine.stat.current;
		}

		protected override void Start()
		{
			base.Start();
			if ( status )
				prepare_status();
		}

		public override void take_damage( List<Damage_struct> damages )
		{
			base.take_damage( damages );
			update_hp_status();
		}

		public virtual string get_damage_description()
		{
			return string.Format(
				"{0} ataco con {1}",
				character_name, attack_weapon.name
				); ;
		}
		public virtual string get_dead_description()
		{
			return string.Format( "{0} a muerto", character_name );
		}
	}
}
