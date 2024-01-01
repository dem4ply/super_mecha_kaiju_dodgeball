using System.Collections.Generic;
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

		public Element_obj(
			string name, string symbol, float atomic_mass, int number )
		{
			this.name = name;
			this.symbol = symbol;
			this.atomic_mass = atomic_mass;
			this.number = number;
		}
	}
}
