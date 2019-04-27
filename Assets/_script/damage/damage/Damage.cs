using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace damage
{
	namespace damage
	{
		[ CreateAssetMenu( menuName="weapon/damage/damage" ) ]
		public class Damage : ScriptableObject
		{
			public float amount = 1;
			public List<type.Damage> effects;
		}
	}
}