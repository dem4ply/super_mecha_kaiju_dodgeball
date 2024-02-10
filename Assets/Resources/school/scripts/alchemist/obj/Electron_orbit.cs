using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace school.alchemist.obj
{
	[System.Serializable]
	public class Electron_orbit_obj
	{
		public string electron_configuration;
		// "[Xe] 4f12 6s2",
		public Dictionary<string, int> orbit_electrons;

		protected Regex re_electrons_config = new Regex( @"\d([fdsp])(\d+)" );
		// 5f14 6d10 7s2 7p6

		public Electron_orbit_obj()
		{
			re_electrons_config = new Regex( @"\d([fdsp])(\d+)" );
			orbit_electrons = new Dictionary<string, int>();
		}

		public Electron_orbit_obj( string electron_configuration ): this()
		{
			this.electron_configuration = electron_configuration;
			build_dict_of_orbits();
		}

		public void build_dict_of_orbits()
		{
			int amount = 0;
			string orbit;

			orbit_electrons.Clear();
			MatchCollection electrons_find =
				re_electrons_config.Matches( electron_configuration );
			foreach ( Match match in electrons_find )
			{
				orbit = match.Groups[1].ToString();
				amount = int.Parse( match.Groups[2].ToString() );
				orbit_electrons[ orbit ] = amount;
			}
		}

		public int get_electrons_of_orbit( string orbit )
		{
			switch( orbit )
			{
				case "s":
					return 2;
				case "p":
					return 6;
				case "d":
					return 10;
				case "f":
					return 14;
				default:
					throw new System.NotImplementedException();
			}
		}

		public int valence_shell
		{
			get{
				int orbit_s = orbit_electrons.GetValueOrDefault( "s", 0 );
				int orbit_p = orbit_electrons.GetValueOrDefault( "p", 0 );
				return orbit_s + orbit_p;
			}
		}
	}
}
