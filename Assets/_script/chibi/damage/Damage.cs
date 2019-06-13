﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace chibi.damage
{
	public class Damage : chibi.Chibi_behaviour {
		public damage.type.Damage damage;
		public chibi.rol_sheet.Rol_sheet owner;
		[HideInInspector] public float amount = 1;

		protected override void _init_cache()
		{
			base._init_cache();
			if ( damage != null )
				amount = damage.amount;
		}

		protected override void Awake()
		{
			base.Awake();
		}
	}
}