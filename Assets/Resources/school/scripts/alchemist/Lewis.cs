using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using school.alchemist.obj;

using UnityEngine;

namespace school.alchemist.elements
{
	public class Lewis: chibi.Chibi_ui
	{
		public TMPro.TMP_Text _symbol;
		public UnityEngine.UI.Image c_1;
		public UnityEngine.UI.Image c_2;
		public UnityEngine.UI.Image c_3;
		public UnityEngine.UI.Image c_4;
		public UnityEngine.UI.Image c_5;
		public UnityEngine.UI.Image c_6;
		public UnityEngine.UI.Image c_7;
		public UnityEngine.UI.Image c_8;

		public List<UnityEngine.UI.Image> circles;

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
			_symbol.text = _element_obj.symbol;
			int valence_shell = element.valence_shell;
			hide_all_circles();
			// TODO: pues me daweba si pasa esto
			if ( valence_shell >= 8 )
				valence_shell = 8;
			for ( int i = 0; i < valence_shell; ++i )
			{
				circles[i].gameObject.SetActive( true );
			}
		}

		public void hide_all_circles()
		{
			foreach( var c in circles )
			{
				c.gameObject.SetActive( false );
			}
		}

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !_symbol )
			{
				debug.error( "el text de symbol no fue asignado" );
			}

			if ( !c_1 )
				debug.error( "el text de c_1 no fue asignado" );
			if ( !c_2 )
				debug.error( "el text de c_2 no fue asignado" );
			if ( !c_3 )
				debug.error( "el text de c_3 no fue asignado" );
			if ( !c_4 )
				debug.error( "el text de c_4 no fue asignado" );
			if ( !c_5 )
				debug.error( "el text de c_5 no fue asignado" );
			if ( !c_6 )
				debug.error( "el text de c_6 no fue asignado" );
			if ( !c_7 )
				debug.error( "el text de c_7 no fue asignado" );
			if ( !c_8 )
				debug.error( "el text de c_8 no fue asignado" );

			circles = new List<UnityEngine.UI.Image>();
			circles.Add( c_1 );
			circles.Add( c_2 );
			circles.Add( c_3 );
			circles.Add( c_4 );
			circles.Add( c_5 );
			circles.Add( c_6 );
			circles.Add( c_7 );
			circles.Add( c_8 );
		}
	}
}
