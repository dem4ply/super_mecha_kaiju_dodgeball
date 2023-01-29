using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;
using chibi.rol_sheet.motor;

namespace rpg.ui
{
	public class RPG_description_battle : chibi.Chibi_behaviour
	{
		public TMPro.TMP_Text description_text;

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !description_text)
			{
				debug.error( "no tiene asgnamdo el texto de la descripcion" );
			}
		}

		public string text
		{
			set {
				description_text.text = value;
			}
		}
	}
}
