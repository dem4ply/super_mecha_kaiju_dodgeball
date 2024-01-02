using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using System;

namespace school.alchemist.obj
{
	[System.Serializable]
	public class Molecule_obj
	{
		public string name;
		public Dictionary<string, Element_obj> elements_by_symbol;

		public Dictionary<Element_obj, int> elements;

		protected string _molecule_str;

		public string molecule_str
		{
			get { return _molecule_str; }
			set
			{
				_molecule_str = value;
				update_elements();
			}
		}

		public Molecule_obj( string molecule_str )
		{
			this._molecule_str = molecule_str;
			elements = new Dictionary<Element_obj, int>();
		}

		public Molecule_obj(
			string molecule_str,
			Dictionary<string, Element_obj> elements_by_symbol ):
			this( molecule_str )
		{
			this.elements_by_symbol = elements_by_symbol;
			update_elements();
		}

		public void update_elements()
		{
			var elements_with_amount = split_string_into_elements( molecule_str );
			this.elements.Clear();
			foreach( var element in elements_with_amount )
			{
				this.elements.Add( element.Item1, element.Item2 );
			}
		}

		public List<Tuple<Element_obj, int>> split_string_into_elements(
			string str )
		{
			Regex re_elements_with_number = new Regex( @"([A-Z][a-z]?)(\d*)" );
			var elements_find = re_elements_with_number.Matches( molecule_str );
			List<Tuple<Element_obj, int>> result =
				new List<Tuple<Element_obj, int>>();
			foreach ( Match match in elements_find )
			{
				int amount = 1;
				string symbol = match.Groups[1].ToString();
				if ( !string.IsNullOrEmpty( match.Groups[2].ToString() ) )
				{
					amount = int.Parse( match.Groups[2].ToString() );
				}
				var element = find_element_by_symbol( symbol );
				if ( element != null )
					result.Add( new Tuple< Element_obj, int >( element, amount ) );
			}
			return result;
		}

		public Element_obj find_element_by_symbol( string symbol )
		{
			Element_obj element;
			elements_by_symbol.TryGetValue( symbol , out element );
			return element;
		}
	}
}
