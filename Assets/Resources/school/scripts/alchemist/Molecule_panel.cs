using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using school.alchemist.obj;

using UnityEngine;
using System.Security;
using System.Diagnostics;
using System.Threading.Tasks;

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

		public Lewis center, left, right, up, down;
		public Lewis up_left, up_right, down_left, down_right;

		public List<Lewis> adjacent_atoms;

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
			lewis_list.Clear();

			var center_element = molecule.find_center_atom();
			debug.info( "atomo central {0}", center_element );
			center.element = center_element;
			center.show();
			hide_atoms_adjacent();
			var adjacent_elements = molecule.find_adjacent_atoms();
			for ( int i = 0; i < adjacent_elements.Count; ++i )
			{
				adjacent_atoms[i].element = adjacent_elements[i];
				adjacent_atoms[i].show();
			}
		}

		public void update_map()
		{
			if ( elements_by_symbol == null )
				elements_by_symbol = new Dictionary<string, Element_obj>();
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

			adjacent_atoms = new List<Lewis>();
			adjacent_atoms.Add( right );
			adjacent_atoms.Add( left );
			adjacent_atoms.Add( up );
			adjacent_atoms.Add( down );
			adjacent_atoms.Add( up_left );
			adjacent_atoms.Add( up_right );
			adjacent_atoms.Add( down_left );
			adjacent_atoms.Add( down_right );

			check_lewis_atoms();
			hide_atoms_adjacent();
			center.hide();
		}

		protected void hide_atoms_adjacent()
		{
			left.hide();
			right.hide();
			down.hide();
			up.hide();
			up_left.hide();
			up_right.hide();
			down.hide();
			down_left.hide();
			down_right.hide();
		}

		protected void check_lewis_atoms()
		{
			if ( !center )
				debug.error( "el atomo lewis central no esta asignado" );
			if ( !up )
				debug.error( "el atomo lewis up no esta asignado" );
			if ( !down )
				debug.error( "el atomo lewis down no esta asignado" );
			if ( !left )
				debug.error( "el atomo lewis left no esta asignado" );
			if ( !right )
				debug.error( "el atomo lewis right no esta asignado" );

			if ( !up_right )
				debug.error( "el atomo lewis up right no esta asignado" );
			if ( !up_left )
				debug.error( "el atomo lewis up left no esta asignado" );

			if ( !down_right )
				debug.error( "el atomo lewis down right no esta asignado" );
			if ( !down_left )
				debug.error( "el atomo lewis down left no esta asignado" );
		}
	}
}
