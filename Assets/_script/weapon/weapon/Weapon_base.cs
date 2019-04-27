using UnityEngine;
using System.Collections;

namespace weapon
{
	namespace weapon
	{
		public abstract class Weapon_base : chibi_base.Chibi_behaviour
		{
			public rol_sheet.Rol_sheet owner;

			public abstract void attack();
		}
	}
}