using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace damage
{
	namespace motor
	{
		namespace stat
		{
			[CreateAssetMenu( menuName = "hp/stat" )]
			public class Hp_stat : chibi_base.Chibi_object
			{
				public float total = 1;
				public float current = 1;
			}
		}
	}
}