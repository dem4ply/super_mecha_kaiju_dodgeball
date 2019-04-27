using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace helper
{
	namespace consts
	{
		public class layers
		{
			public static LayerMask damage
			{
				get {
					return LayerMask.NameToLayer( "damage" );
				}
			}

			public static LayerMask receives_damage
			{
				get {
					return LayerMask.NameToLayer( "receives_damage" );
				}
			}
		}
	}
}
