using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using school.alchemist.obj;

using UnityEngine;

namespace school.alchemist.elements
{
	public class Element: chibi.Chibi_behaviour
	{
		public TMPro.TMP_Text name;
		public TMPro.TMP_Text atomic_mass;
		public TMPro.TMP_Text symbol;
		public TMPro.TMP_Text number;

		protected Element_obj _element_obj;


		public Element_obj element
		{
			set
			{
				_element_obj = value;
				update_text();
			}
		}

		public void update_text()
		{
			name.text = _element_obj.name;
			atomic_mass.text = _element_obj.atomic_mass.ToString();
			symbol.text = _element_obj.symbol;
			number.text = _element_obj.number.ToString();
		}

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !name )
			{
				debug.error( "el text de name no fue asignado" );
			}

			if ( !atomic_mass)
			{
				debug.error( "el text de atomic_mass no fue asignado" );
			}

			if ( !symbol )
			{
				debug.error( "el text de symbol no fue asignado" );
			}

			if ( !number )
			{
				debug.error( "el text de number no fue asignado" );
			}
		}

		public void Update()
		{
		}
	}
}
