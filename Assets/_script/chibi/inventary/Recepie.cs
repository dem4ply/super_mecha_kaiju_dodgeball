using System.Collections.Generic;
using chibi.rol_sheet;
using UnityEngine;


namespace chibi.inventory
{
	[System.Serializable]
	public class Recepie_item
	{
	}

	[ CreateAssetMenu( menuName="chibi/inventary/recepie/base" ) ]
	public class Recepie : chibi.Chibi_object
	{
		public List<Recepie_item> items;
		public List<Recepie_item> tools;
		public List<Recepie_item> machines;
	}
}
