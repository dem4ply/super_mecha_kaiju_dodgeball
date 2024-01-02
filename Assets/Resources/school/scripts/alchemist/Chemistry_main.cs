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

		public Transform lewis_grid;
		public Lewis prefab_lewis;

		public List<Element> elements;
		public Dictionary<string, Element> elements_by_symbol;

		public List<Lewis> lewis;
		public Dictionary<string, Lewis> lewis_by_symbol;

		protected Regex re_elements_with_number = new Regex( @"[A-Z][a-z]?\d*" );
		protected Regex re_elements = new Regex( @"[A-Z][a-z]?" );

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
				elements_by_symbol = new Dictionary<string, Element>();

				lewis = new List<Lewis>();
				lewis_by_symbol = new Dictionary<string, Lewis>();

				foreach ( var element in _elements_list.elements )
				{
					Element element_inst  = helper.instantiate.parent<Element>(
						prefab_elements, element_grid );
					element_inst.element = element;
					elements.Add( element_inst );
					elements_by_symbol.Add( element_inst.symbol, element_inst );

					Lewis lewis_inst = helper.instantiate.parent<Lewis>(
						prefab_lewis, lewis_grid );
					lewis_inst.element = element;
					lewis.Add( lewis_inst );
					lewis_by_symbol.Add( lewis_inst.symbol, lewis_inst );
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
			if ( string.IsNullOrEmpty( text ) )
			{
				show_all_elements();
				return;
			}

			MatchCollection elements_find = re_elements.Matches( text );
			hide_all_elements();
			Element element;
			Lewis lewin;

			foreach ( Match match in elements_find )
			{
				elements_by_symbol.TryGetValue( match.Value, out element );
				if ( element )
					element.show();

				lewis_by_symbol.TryGetValue( match.Value, out lewin );
				if ( lewin )
					lewin.show();
			}
		}

		public void hide_all_elements()
		{
			foreach( Element element in elements )
				element.hide();
			foreach( Lewis element in lewis )
				element.hide();
		}

		public void show_all_elements()
		{
			foreach( Element element in elements )
				element.show();
			foreach( Lewis element in lewis )
				element.show();
		}
	}
}
