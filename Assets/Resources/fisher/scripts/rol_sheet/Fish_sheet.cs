using UnityEngine;
using System.Collections.Generic;
using chibi.rol_sheet.buff;


namespace fisher.rol_sheet
{
	public class Fish_sheet : chibi.rol_sheet.Rol_sheet
	{
		public chibi.rol_sheet.gender.Gender gender;
		public chibi.tool.reference.Need_reference reproduction;
		public bool want_to_reproducing = false;

		public fisher.tool.fish_set all_fish;
		public fisher.tool.fish_specie_set specie;

		private void OnEnable()
		{
			all_fish.add( this );
			specie.add( this );
		}

		private void OnDisable()
		{
			all_fish.remove( this );
			specie.add( this );
		}
	}
}