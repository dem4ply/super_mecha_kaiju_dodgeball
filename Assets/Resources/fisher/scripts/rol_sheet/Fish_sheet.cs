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
	}
}