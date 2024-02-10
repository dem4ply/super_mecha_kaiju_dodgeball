using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace school.alchemist.obj
{
	[System.Serializable]
	public class Element_obj
	{
		public string name;
		public string symbol;
		public float atomic_mass;
		public int number;
		public string electron_configuration_semantic;
		// "[Xe] 4f12 6s2",
		public float electronegativity_pauling;

		protected Electron_orbit_obj _electron_orbit;
		protected Regex re_electrons_config = new Regex( @"\d[A-Za-z](\d+)" );

		public Electron_orbit_obj electron_orbit
		{
			get
			{
				if ( _electron_orbit == null )
					_electron_orbit = new Electron_orbit_obj(
						electron_configuration_semantic );
				return _electron_orbit;
			}
		}

		public Element_obj()
		{
			re_electrons_config = new Regex( @"\d[A-Za-z](\d+)" );
		}

		public int valence_shell
		{
			get{
				return electron_orbit.valence_shell;
			}
		}

		public override string ToString()
		{
			return string.Format( "[{0}]", symbol );
		}
	}
}
