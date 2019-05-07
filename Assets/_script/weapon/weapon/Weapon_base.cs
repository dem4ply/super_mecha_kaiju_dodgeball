namespace weapon
{
	namespace weapon
	{
		public abstract class Weapon_base : chibi_base.Chibi_behaviour
		{
			public chibi.rol_sheet.Rol_sheet owner;

			public abstract void attack();
		}
	}
}