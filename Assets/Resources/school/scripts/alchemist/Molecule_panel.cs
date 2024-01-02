using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using school.alchemist.obj;

using UnityEngine;

namespace school.alchemist.elements
{
	public class Molecule_panel: chibi.Chibi_ui
	{
		public Transform panel_parent;
		public Lewis prefab_lewis;

		public Dictionary<string, Element_obj> elements_by_symbol;

		public Molecule_obj molecule;

		public List<Element_obj> elements;
		public List<Lewis> lewis_list;

		public string molecule_str
		{
			get
			{
				return molecule.molecule_str;
			}
			set
			{
				molecule.molecule_str = value;
				update_molecule();
			}
		}

		public void update_molecule()
		{
			foreach( var lewis in lewis_list )
			{
				lewis.recycle();
			}
			lewis_list.Clear();

			foreach( var element in molecule.elements.Keys )
			{
				int amount = molecule.elements[ element ];
				for ( int i = 0; i < amount; ++i )
				{
					Lewis lewis_inst = helper.instantiate.parent<Lewis>(
						prefab_lewis, panel_parent );
					lewis_inst.element = element;
					lewis_list.Add( lewis_inst );
				}
			}
		}

		public void update_map()
		{
			elements_by_symbol.Clear();
			foreach ( var element in elements )
			{
				elements_by_symbol[ element.symbol ] = element;
			}
		}

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !prefab_lewis )
			{
				debug.error( "el prefab de lewis no esta asignado" );
			}
			if ( !panel_parent)
			{
				debug.error( "el panel_parent no fue asignado" );
			}
			if ( elements_by_symbol == null )
				elements_by_symbol = new Dictionary<string, Element_obj>();

			lewis_list = new List<Lewis>();
			molecule = new Molecule_obj( "", elements_by_symbol );
		}
	}
}
