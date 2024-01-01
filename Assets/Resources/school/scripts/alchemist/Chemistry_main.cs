using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using school.alchemist.obj;
using school.alchemist.elements;

using UnityEngine;

namespace school.alchemist.main
{
	public class Chemistry_main: chibi.Chibi_behaviour
	{
		public TMPro.TMP_InputField molecule_text;
		public string peridict_table_path = "";
		public Transform element_grid;
		public Element prefab_elements;

		public List<Element> elements;

		protected Regex re_elements = new Regex( @"[A-Z][a-z]?\d*" );

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !molecule_text)
			{
				debug.error( "no tiene asignado el texto de las moleculas" );
			}

			if ( string.IsNullOrEmpty( peridict_table_path ) )
			{
				debug.error( "no asigno el path para la tabla peridica" );
			}
			else
			{
				TextAsset file = Resources.Load<TextAsset>( peridict_table_path );

				var _elements_list = JsonUtility.FromJson<Element_list>( file.text );
				elements = new List<Element>();
				foreach ( var element in _elements_list.elements )
				{
					Element element_inst  = helper.instantiate.parent<Element>(
						prefab_elements, element_grid );
					element_inst.element = element;
					elements.Add( element_inst );
				}
			}
		}

		public void Update()
		{
			// debug.info( "molecula escrita {0}", molecule_text.text );
		}

		public void on_change_molecule_text( string text )
		{
			if ( string.IsNullOrEmpty( text ) )
				text = molecule_text.text;
			MatchCollection elements_find = re_elements.Matches( text );
			List<string> elements = new List<string>();

			foreach ( Match match in elements_find )
				elements.Add( match.Value );
			string str_elements = string.Join( ", ", elements );
			debug.info( str_elements );
		}
	}
}
