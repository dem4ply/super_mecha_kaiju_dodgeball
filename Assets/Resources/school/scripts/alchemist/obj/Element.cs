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

		protected Regex re_electrons_config = new Regex( @"\d[A-Za-z](\d+)" );

		public Element_obj()
		{
			re_electrons_config = new Regex( @"\d[A-Za-z](\d+)" );
		}

		public Element_obj(
			string name, string symbol, float atomic_mass, int number ): this()
		{
			this.name = name;
			this.symbol = symbol;
			this.atomic_mass = atomic_mass;
			this.number = number;
		}

		public int valence_shell
		{
			get{
				int result = 0;
				MatchCollection electrons_find =
					re_electrons_config.Matches( electron_configuration_semantic );
				foreach ( Match match in electrons_find )
				{
					result += int.Parse( match.Groups[1].ToString() );
				}
				return result;
			}
		}
	}
}
