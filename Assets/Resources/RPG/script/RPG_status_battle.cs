using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;
using chibi.rol_sheet.motor;

namespace rpg.ui
{
	public class RPG_status_battle : chibi.Chibi_behaviour
	{
		public TMPro.TMP_Text status_name_text;
		public TMPro.TMP_Text hp_text;
		public UnityEngine.UI.Slider hp_bar;

		public chibi.damage.motor.HP_engine hp_engine;

		public string status_name
		{
			get {
				return status_name_text.text;
			}
			set {
				status_name_text.text = value;
				if ( value == "" )
				{
					debug.error( "el status name se asigno vacio" );
				}
			}
		}

		public int hit_points
		{
			set {
				hp_text.text = string.Format( "{0} / {1}", value, max_hp );
				if ( has_hp_engine )
				{
					hp_bar.value = hp_engine.stat.ratio;
				}
			}
		}

		public string max_hp
		{
			get {
				if ( has_not_hp_engine )
				{
					return "##";
				}

				return string.Format( "{0}", hp_engine.stat.max );
			}
		}

		public bool has_hp_engine
		{
			get {
				if ( !hp_engine )
				{
					debug.warning(
						"no tiene hp engine no se puede determinar el maximo de hp" );
					return false;
				}
				return true;
			}
		}

		public bool has_not_hp_engine
		{
			get {
				return !has_hp_engine;
			}
		}

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !status_name_text )
			{
				debug.error( "no tiene asgnamdo el texto de name" );
			}
			if ( !hp_text )
			{
				debug.error( "no tiene asgnamdo el texto del hp" );
			}
			if ( !hp_bar )
			{
				debug.error( "no tiene asgnamdo el slider de la barra de hp" );
			}
		}
	}
}
