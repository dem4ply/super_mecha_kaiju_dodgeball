using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using school.alchemist.obj;

using UnityEngine;

namespace school.alchemist.elements
{
	public class Element: chibi.Chibi_ui
	{
		public TMPro.TMP_Text _name;
		public TMPro.TMP_Text _atomic_mass;
		public TMPro.TMP_Text _symbol;
		public TMPro.TMP_Text _number;

		protected Element_obj _element_obj;

		public string name_symbol
		{
			get{ return element.name; }
		}

		public string symbol
		{
			get{ return element.symbol; }
		}


		public Element_obj element
		{
			get { return _element_obj; }
			set
			{
				_element_obj = value;
				update_text();
			}
		}

		public void update_text()
		{
			_name.text = _element_obj.name;
			_atomic_mass.text = _element_obj.atomic_mass.ToString();
			_symbol.text = _element_obj.symbol;
			_number.text = _element_obj.number.ToString();
		}

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !_name )
			{
				debug.error( "el text de name no fue asignado" );
			}

			if ( !_atomic_mass)
			{
				debug.error( "el text de atomic_mass no fue asignado" );
			}

			if ( !_symbol )
			{
				debug.error( "el text de symbol no fue asignado" );
			}

			if ( !_number )
			{
				debug.error( "el text de number no fue asignado" );
			}
		}
	}
}
